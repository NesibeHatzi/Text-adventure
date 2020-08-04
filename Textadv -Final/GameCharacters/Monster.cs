using System;
using System.IO;
using Newtonsoft.Json;

namespace Program.GameCharacters
{
    public class Monster : Character
    {
        public int Attack { get; set; }


        public static Monster CreateMonster(string monsterFileName)
        {
            string       projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string       path        = projectPath + @"\JSON\Characters\Monsters\" + monsterFileName;
            StreamReader reader      = new StreamReader(path);
            string       jsonData    = reader.ReadToEnd();
            reader.Close();
            Monster loadedMonster = JsonConvert.DeserializeObject<Monster>(jsonData);
            return loadedMonster;
        }
    }
}