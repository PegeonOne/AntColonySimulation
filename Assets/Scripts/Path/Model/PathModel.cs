using UnityEngine;

namespace Colony.Models.Path
{
    public sealed class PathModel
    {
        public readonly float pathID;
        public readonly GameObject fromCity;
        public readonly GameObject toCity;
        public readonly float distance;
        public float pheromon;
        public float pheromonCollectedOnIteration;
        public Color color;
        public bool RebuildPath;

        public PathModel()
        {

        }

        public PathModel(float _pathID, GameObject _fromCityName, GameObject _toCityName, float _dist, float _pheromon, bool _rebuildPath)
        {
            pathID = _pathID;
            fromCity = _fromCityName;
            toCity = _toCityName;
            distance = _dist;
            pheromon = _pheromon;
            color = new Color(0, 1, 1, 0);
            RebuildPath = _rebuildPath;
        }
    }
}

