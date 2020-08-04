using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Program.GameCharacters;
using Program.GameItems;

namespace Program.GameLocations
{
    public class Location
    {
        // Data read from JSON-file
        public string   Name;
        public string   BaseDescription;
        public string   FriendlyJsonFileName;
        public string   FriendlyDescription;
        public string   MonsterJsonFileName;
        public string   MonsterDescription;
        public string[] ItemJsonFileNames;
        public string   NorthOf;
        public string   EastOf;
        public string   SouthOf;
        public string   WestOf;

        public bool IsMonsterAlive
        {
            get
            {
                return LocationMonster != null;
            }
        }

        public string     Description { get; protected set; }
        public List<Item> Items = new List<Item>();
        public Monster    LocationMonster  { get; protected set; }
        public Friendly   LocationFriendly { get; protected set; }


        public void KillLocationMonster()
        {
            LocationMonster = null;
            Description     = BaseDescription;
        }


        public void UpdateLocationDescriptions()
        {
            // Description
            Description = BaseDescription + "\n";
            if (IsMonsterAlive)
                Description += MonsterDescription.Replace("MONSTER_NAME", LocationMonster.Name) + " - Want to fight? Yes (f); No (x)\n";
            if (LocationFriendly != null)
                Description += FriendlyDescription.Replace("FRIENDLY_NAME", LocationFriendly.Name + " - Do you want to talk (o)?\n");
        }


        public static Location CreateLocation(string locationFileName)
        {
            string       projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string       path        = projectPath + @"\JSON\Locations\" + locationFileName;
            StreamReader reader      = new StreamReader(path);
            string       jsonData    = reader.ReadToEnd();
            reader.Close();
            Location loadedLocation = JsonConvert.DeserializeObject<Location>(jsonData);

            // Get all monsters and select the one we need
            CreateMonster(loadedLocation);

            // Get all friendlies and select the one we need
            CreateFriendly(loadedLocation);

            loadedLocation.UpdateLocationDescriptions();

            CreateWeapons(loadedLocation);
            CreateArmors(loadedLocation);

            return loadedLocation;
        }


        private static void CreateMonster(Location loadedLocation)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string path        = projectPath + @"\JSON\Characters\Monsters\";
            foreach (string fileName in Directory.GetFiles(path, "*.json").Select(Path.GetFileName))
                if (fileName == loadedLocation.MonsterJsonFileName + ".json")
                    loadedLocation.LocationMonster = Monster.CreateMonster(fileName);
        }


        private static void CreateFriendly(Location loadedLocation)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string path        = projectPath + @"\JSON\Characters\Friendlies\";
            foreach (string fileName in Directory.GetFiles(path, "*.json").Select(Path.GetFileName))
                if (fileName == loadedLocation.FriendlyJsonFileName + ".json")
                    loadedLocation.LocationFriendly = Friendly.CreateFriendly(fileName);
        }


        private static void CreateWeapons(Location loadedLocation)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string path        = projectPath + @"\JSON\Items\Weapons\";

            foreach (string weaponItemName in loadedLocation.ItemJsonFileNames)
            foreach (string fileName in Directory.GetFiles(path, "*.json").Select(Path.GetFileName))
                if (fileName == weaponItemName + ".json")
                    loadedLocation.Items.Add(Weapon.CreateWeapon(fileName));
        }


        private static void CreateArmors(Location loadedLocation)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string path        = projectPath + @"\JSON\Items\Armors\";


            foreach (string armorItemName in loadedLocation.ItemJsonFileNames)
            foreach (string fileName in Directory.GetFiles(path, "*.json").Select(Path.GetFileName))
                if (fileName == armorItemName + ".json")
                    loadedLocation.Items.Add(Armor.CreateArmor(fileName));
        }
    }
}