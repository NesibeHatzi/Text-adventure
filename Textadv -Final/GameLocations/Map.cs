using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Program.GameLocations
{
    internal class Map
    {
        public List<Location> Locations = new List<Location>();


        public Map()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string path        = projectPath + @"\JSON\Locations\";

            foreach (string fileName in Directory.GetFiles(path, "*.json").Select(Path.GetFileName))
                Locations.Add(Location.CreateLocation(fileName));
        }


        public Location GetLocationByName(string name)
        {
            foreach (Location location in Locations)
                if (name == location.Name)
                    return location;

            return null;
        }


        public Location NorthOf(Location reference)
        {
            foreach (Location location in Locations)
            {
                if (location == reference) continue;

                if (reference.NorthOf == location.Name)
                    return location;
            }

            return null;
        }


        public Location SouthOf(Location reference)
        {
            foreach (Location location in Locations)
            {
                if (location == reference) continue;

                if (reference.SouthOf == location.Name)
                    return location;
            }

            return null;
        }


        public Location EastOf(Location reference)
        {
            foreach (Location location in Locations)
            {
                if (location == reference) continue;

                if (reference.EastOf == location.Name)
                    return location;
            }

            return null;
        }


        public Location WestOf(Location reference)
        {
            foreach (Location location in Locations)
            {
                if (location == reference) continue;

                if (reference.WestOf == location.Name)
                    return location;
            }

            return null;
        }
    }
}