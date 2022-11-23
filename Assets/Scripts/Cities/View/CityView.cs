using Colony.Models.ColonyModel;
using Colony.Core.Implementation;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Colony.City.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CityView : ViewWithModel<ColonyModel>
    {
        public int CityID;
        public Vector2 CityPosition;

        public void InitCity(int id, Vector2 cityPosition, ColonyModel model, Sprite visual)
        {
            CityID = id;
            CityPosition = cityPosition;
            Model = model;
            gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
            gameObject.GetComponent<SpriteRenderer>().sprite = visual;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            gameObject.transform.position = cityPosition;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}

