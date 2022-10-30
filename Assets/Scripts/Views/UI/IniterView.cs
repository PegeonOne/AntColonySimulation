using Colony.Models.ColonyModel;
using Colony.Views.Implementation;
using Colony.Views.Map.View;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Colony.Views.UI.IniterView
{
    public class IniterView : ViewWithModel<ColonyModel>
    {
        [SerializeField]
        Button InitButton;
        [SerializeField]
        InputField AntCountField;
        [SerializeField]
        InputField CityCountField;
        [SerializeField]
        MapView MapView;
        [SerializeField]
        GameObject City;
        [SerializeField] GameObject Path;


        protected override void OnAwake()
        {
            base.OnAwake();
            InitButton.onClick.AddListener(OnColonyInit);
        }

        private void OnColonyInit()
        {
            Model = new ColonyModel(Int32.Parse(AntCountField.text), Int32.Parse(CityCountField.text), CreateCitiesInstances()) ;
            MapView.Model = Model;
            gameObject.SetActive(false);
        }

        GameObject[] CreateCitiesInstances()
        {
            int cityCount = Int32.Parse(CityCountField.text);
            GameObject[] array = new GameObject[cityCount];
            for (int i = 0; i < cityCount; i++)
            {
                GameObject city = Instantiate(City, new Vector2(-5, 5), Quaternion.identity);
                city.name = "City" + (i + 1);
                array[i] = city;
            }
            return array;
        }
    }
}

