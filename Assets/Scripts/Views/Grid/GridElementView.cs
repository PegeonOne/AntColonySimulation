using Colony.Models.PathModel;
using Colony.Views.Implementation;
using UnityEngine;
using UnityEngine.UI;

namespace Colony.Views.Grid.GridElements.View
{
    public class GridElementView : ViewWithModel<PathModel>
    {
        [SerializeField] Text DistanceText;
        [SerializeField] Text PheromonText;

        public override void OnModelChanged()
        {
            base.OnModelChanged();
            DistanceText.text = Model.distance.ToString();
            PheromonText.text = Model.pheromon.ToString();
        }
    }
}

