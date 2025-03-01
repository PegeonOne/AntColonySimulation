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
        int qParam;

        public int Q
        {
            get { return qParam; }
            set { qParam = value; }
        }
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
            set { pheromonInfluence = value; }
        }
        public int ClosenessInfluence
        {
            get { return closnessInfluence; }
            set { closnessInfluence = value; }
        }
        public int CityCount { get { return cityCount; } }
        public int AntCount { get { return antCount; } set { antCount = value; } }

        public int Iterations { get { return iterations; } set { iterations = value; } }

        public GameObject[] CitiesGameObjects;

        public List<string> CitiesID = new List<string>();

        public readonly Dictionary<int, CityView> CityDatas = new Dictionary<int, CityView>();
        public readonly Dictionary<string, PathView> Paths = new Dictionary<string, PathView>();
        public readonly List<AntView> Ants = new List<AntView>();
        public List<GameObject> AntsObjs = new List<GameObject>();
        public float[,] Pheromons;

        public ColonyModel(int _antCount, int _cityCount, int _closenessInf, int _pheromoneInf, int _q, GameObject[] _cityArray)
        {
            this.antCount = _antCount;
            this.cityCount = _cityCount;
            this.closnessInfluence = _closenessInf;
            this.pheromonInfluence = _pheromoneInf;
            this.CitiesGameObjects = _cityArray;
            this.qParam = _q;
        }
    }  
}

