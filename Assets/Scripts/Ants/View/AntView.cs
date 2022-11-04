using Colony.Ant.Controller;
using Colony.Core.Implementation;
using Colony.Models.ColonyModel;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Colony.Ant.View
{
    [RequireComponent(typeof(AntController))]
    public class AntView : ViewWithModel<ColonyModel>
    {
        public string StartCity;

        public bool FinishedIteration;

        public List<string> VisitedCities = new List<string>();

        public event Action<float, List<string>> OnAntFinishedIteration;

        public void AntFinish(float dist, List<string> paths)
        {
            OnAntFinishedIteration?.Invoke(dist, paths);
        }
    }
}

