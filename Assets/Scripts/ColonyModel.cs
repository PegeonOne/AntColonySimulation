using Colony.Models.Path;
using Colony.Views.Map.Path;
using System.Collections.Generic;
using UnityEngine;

namespace Colony.Models.ColonyModel
{
    public sealed class ColonyModel
    {
        int cityCount;
        public int CityCount { get { return cityCount; } }
        private int antCoutn;

        public GameObject[] Cities;

        public Vector2[] CitiesCoords;

        public readonly Dictionary<string, City> Distances = new Dictionary<string, City>();
        public readonly Dictionary<int, PathView> Paths = new Dictionary<int, PathView>();
        public float[,] Pheromons;

        public ColonyModel(int _antCount, int _cityCount, GameObject[] _cityArray)
        {
            this.antCoutn = _antCount;
            this.cityCount = _cityCount;
            this.CitiesCoords = new Vector2[_cityCount];
            this.Cities = _cityArray;
        }
    }

    public struct City
    {
        public string Name;
        public Vector2 Coordinates;

        public City(string name, Vector2 coords)
        {
            Name = name;
            Coordinates = coords;
        }
    }  
}

