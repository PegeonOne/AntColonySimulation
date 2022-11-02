using Colony.City.View;
using Colony.City.Map.Path;
using System.Collections.Generic;
using UnityEngine;

namespace Colony.Models.ColonyModel
{
    public sealed class ColonyModel
    {
        int cityCount;
        int antCount;
        public int CityCount { get { return cityCount; } }
        public int AntCount { get { return antCount; } }

        public GameObject[] CitiesGameObjects;

        public List<string> CitiesID = new List<string>();

        public readonly Dictionary<int, CityView> CityDatas = new Dictionary<int, CityView>();
        public readonly Dictionary<string, PathView> Paths = new Dictionary<string, PathView>();
        public float[,] Pheromons;

        public ColonyModel(int _antCount, int _cityCount, GameObject[] _cityArray)
        {
            this.antCount = _antCount;
            this.cityCount = _cityCount;
            this.CitiesGameObjects = _cityArray;
        }
    }  
}

