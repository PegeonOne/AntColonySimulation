using Colony.Models.Path;
using Colony.Core.Implementation;
using UnityEngine;

namespace Colony.City.Map.Path
{
    [RequireComponent(typeof(LineRenderer))]
    public class PathView : ViewWithModel<PathModel>
    {
        LineRenderer PathLine;
        [HideInInspector] public Material material;
        protected override void OnStart()
        {
            base.OnStart();
            PathLine = gameObject.GetComponent<LineRenderer>();
            PathLine.positionCount = 2;
            PathLine.startWidth = 0.1f;
            PathLine.endWidth = 0.1f;
            PathLine.material = material;
            PathLine.SetPosition(0, Model.fromCity.transform.position);
            PathLine.SetPosition(1, Model.toCity.transform.position);
            PathLine.material.color = new Color(0, 1, 1, 1f / Model.distance);
        }
    }
}

