using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini_RPG
{
    [Serializable]
    class CampainFile
    {
        public List<string> MapList = new List<string>();
        public CampainFile()
        {

        }
        public void AddMap(string mapName)
        {
            MapList.Add(mapName);
        }
        public void RemoveMap(string mapName)
        {
            try
            {
                MapList.Remove(mapName);
            }
            catch
            {

            }
        }
    }
}
