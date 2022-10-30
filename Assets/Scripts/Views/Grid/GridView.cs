using Colony.Models.ColonyModel;
using Colony.Views.Grid.GridElements.View;
using Colony.Views.Implementation;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Colony.Views.Grid
{
    public class GridView : ViewWithModel<ColonyModel>
    {
        [SerializeField] GridLayout GridLayout;
        [SerializeField] GameObject GridElement;

        [SerializeField] GameObject RowObject;
        [SerializeField] GameObject ColumnObject;

    }
}

