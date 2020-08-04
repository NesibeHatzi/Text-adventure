using System.Collections.Generic;
using Program.GameCharacters;
using Program.GameItems;
using Program.GameLocations;

namespace Program
{
    public class Avatar : Character
    {
        public Location        Location   { get; set; }
        public List<Item>      Inventory  { get; }
        public List<Character> Characters { get; }
        public int             Attack     { get; set; }

        private int startHealth = 100;


        public Avatar() : base("Avatar", 100)
        {
            Inventory  = new List<Item>();
            Characters = new List<Character>();

            Attack = 35;
            Health = startHealth;

            RestoreHealth();
        }


        public void RestoreHealth(int bonus = 0)
        {
            Health = startHealth + bonus;
        }
    }
}