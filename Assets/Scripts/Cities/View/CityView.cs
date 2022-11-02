using Colony.Models.ColonyModel;
using Colony.Core.Implementation;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Colony.City.View
{
    public class CityView : ViewWithModel<ColonyModel>
    {
        public int CityID;
        public Vector2 CityPosition;

        public void InitCity(int id, Vector2 cityPosition, ColonyModel model)
        {
            this.CityID = id;
            this.CityPosition = cityPosition;
            this.Model = model;
            gameObject.transform.position = cityPosition;
        }

        public event Action<int> InitAnts;

        protected override void OnStart()
        {
            base.OnStart();
            InitAnts?.Invoke(Model.AntCount);
        }
    }
}

