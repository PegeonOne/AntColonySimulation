using Colony.Models.PathModel;
using Colony.Views.Implementation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Colony.Views.Map.Path
{
    public class PathView : ViewWithModel<PathModel>
    {
        [SerializeField] LineRenderer PathLine;

    }
}

