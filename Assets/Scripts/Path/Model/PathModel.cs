using UnityEngine;

namespace Colony.Models.Path
{
    public sealed class PathModel
    {
        public readonly float pathID;
        public readonly GameObject fromCity;
        public readonly GameObject toCity;
        public readonly float distance;
        public readonly float pheromon;

        public PathModel(float _pathID, GameObject _fromCityName, GameObject _toCityName, float _dist, float _pheromon)
        {
            pathID = _pathID;
            fromCity = _fromCityName;
            toCity = _toCityName;
            distance = _dist;
            pheromon = _pheromon;
        }
    }
}

