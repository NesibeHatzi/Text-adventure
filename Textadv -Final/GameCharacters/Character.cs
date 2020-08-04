namespace Program.GameCharacters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (health < 0)
                    health = 0;
            }
        }

        private int health;

        protected Character() { }


        protected Character(string name, int health)
        {
            Name   = name;
            Health = health;
        }
    }
}