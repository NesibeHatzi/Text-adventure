using System;
using System.IO;
using Newtonsoft.Json;

namespace Program.GameItems
{
    public class Weapon : Item
    {
        public int Damage        { get; set; }
        public int HandsRequired { get; set; }


        public static Weapon CreateWeapon(string fileName)
        {
            string       projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string       path        = projectPath + @"\JSON\Items\Weapons\" + fileName;
            StreamReader reader      = new StreamReader(path);
            string       jsonData    = reader.ReadToEnd();
            reader.Close();
            Weapon loadedWeapon = JsonConvert.DeserializeObject<Weapon>(jsonData);
            return loadedWeapon;
        }
    }
}