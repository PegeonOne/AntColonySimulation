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
            PathLine.startWidth = Mathf.Clamp(Model.pheromon, 0.05f, 0.2f);
            PathLine.endWidth = Mathf.Clamp(Model.pheromon, 0.05f, 0.2f);
            PathLine.material = material;
            PathLine.SetPosition(0, Model.fromCity.transform.position);
            PathLine.SetPosition(1, Model.toCity.transform.position);
            PathLine.material.color = Model.color;
        }

        public override void OnModelChanged()
        {
            base.OnModelChanged();
            if (PathLine && Model.RebuildPath)
            {
                PathLine.startWidth = Mathf.Clamp(Model.pheromon, 0.05f, 0.1f);
                PathLine.endWidth = Mathf.Clamp(Model.pheromon, 0.05f, 0.1f);
                PathLine.material.color = Model.color;
            }
        }
    }
}

