
namespace Colony.Models.PathModel
{
    public sealed class PathModel
    {
        public readonly string fromCityName;
        public readonly string toCityName;
        public readonly float distance;
        public readonly float pheromon;

        public PathModel(string _fromCityName, string _toCityName, float _dist, float _pheromon)
        {
            fromCityName = _fromCityName;
            toCityName = _toCityName;
            distance = _dist;
            pheromon = _pheromon;
        }
    }
}

