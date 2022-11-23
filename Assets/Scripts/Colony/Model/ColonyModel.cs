using Colony.City.View;
using Colony.City.Map.Path;
using System.Collections.Generic;
using UnityEngine;
using Colony.Ant.View;

namespace Colony.Models.ColonyModel
{
    public sealed class ColonyModel
    {
        int cityCount;
        int antCount;
        int iterations;
        int closnessInfluence;
        int pheromonInfluence;
        float minimalDistance;

        public float MinimalDistance
        {
            get { return minimalDistance; }
            set
            {
                minimalDistance = value;
            }
        }
        public int PheromonInfluence
        {
            get { return pheromonInfluence; }
        }
        public int ClosenessInfluence
        {
            get { return closnessInfluence; }
        }
        public int CityCount { get { return cityCount; } }
        public int AntCount { get { return antCount; } }

        public int Iterations { get { return iterations; } set { iterations = value; } }

        public GameObject[] CitiesGameObjects;

        public List<string> CitiesID = new List<string>();

        public readonly Dictionary<int, CityView> CityDatas = new Dictionary<int, CityView>();
        public readonly Dictionary<string, PathView> Paths = new Dictionary<string, PathView>();
        public readonly List<AntView> Ants = new List<AntView>();
        public float[,] Pheromons;

        public ColonyModel(int _antCount, int _cityCount, int _closenessInf, int _pheromoneInf, GameObject[] _cityArray)
        {
            this.antCount = _antCount;
            this.cityCount = _cityCount;
            this.closnessInfluence = _closenessInf;
            this.pheromonInfluence = _pheromoneInf;
            this.CitiesGameObjects = _cityArray;
        }
    }  
}

