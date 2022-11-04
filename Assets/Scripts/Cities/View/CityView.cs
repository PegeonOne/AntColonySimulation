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
            CityID = id;
            CityPosition = cityPosition;
            Model = model;
            gameObject.transform.position = cityPosition;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}

