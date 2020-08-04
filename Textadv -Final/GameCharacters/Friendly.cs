using System;
using System.IO;
using Newtonsoft.Json;

namespace Program.GameCharacters
{
    public class Friendly : Character
    {
        public int Power { get; set; }


        public static Friendly CreateFriendly(string friendlyFileName)
        {
            string       projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string       path        = projectPath + @"\JSON\Characters\Friendlies\" + friendlyFileName;
            StreamReader reader      = new StreamReader(path);
            string       jsonData    = reader.ReadToEnd();
            reader.Close();
            Friendly loadedFriendly = JsonConvert.DeserializeObject<Friendly>(jsonData);
            return loadedFriendly;
        }
    }
}