using System;
using System.IO;
using Newtonsoft.Json;

namespace Program.GameItems
{
    public class Armor : Item
    {
        public int Weight;
        public int Protection;


        public static Armor CreateArmor(string fileName)
        {
            string       projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string       path        = projectPath + @"\JSON\Items\Armors\" + fileName;
            StreamReader reader      = new StreamReader(path);
            string       jsonData    = reader.ReadToEnd();
            reader.Close();
            Armor loadedArmor = JsonConvert.DeserializeObject<Armor>(jsonData);
            return loadedArmor;
        }
    }
}