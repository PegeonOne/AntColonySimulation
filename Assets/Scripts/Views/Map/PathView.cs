using Colony.Models.Path;
using Colony.Views.Implementation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Colony.Views.Map.Path
{
    public class PathView : ViewWithModel<PathModel>
    {
        [SerializeField] LineRenderer PathLine;

        protected override void OnStart()
        {
            base.OnStart();
            PathLine.positionCount = 2;
            
        }

        public void CreatePath()
        {
            PathLine.SetPosition(0, Model.fromCity.transform.position);
            PathLine.SetPosition(1, Model.toCity.transform.position);
            PathLine.material.color = new Color(0, 1, 1, 0.01f * Model.distance);
        }
    }
}

