using Colony.Models.ColonyModel;
using Colony.Views.Implementation;
using Colony.Views.Map.Path;
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

        protected override void OnAwake()
        {
            base.OnAwake();
            InitButton.onClick.AddListener(OnColonyInit);
        }

        private void OnColonyInit()
        {
            int cities = Int32.Parse(CityCountField.text);
            int ants = Int32.Parse(AntCountField.text);
            Model = new ColonyModel(ants, cities, CreateCitiesInstances()) ;
            
            GenerateCities();
            gameObject.SetActive(false);
        }

        public void GenerateCities()
        {
            Vector2 maxSquare = new Vector2(11, 7f);
            Vector2 minSquare = new Vector2(-11, -5f);
            Debug.Log(Model.CityCount);
            for (int i = 0; i < Model.CityCount; i++)
            {
                float cityXPos = UnityEngine.Random.Range(minSquare.x, maxSquare.x);
                float cityYPos = UnityEngine.Random.Range(minSquare.y, maxSquare.y);
                Vector2 cityPosition = new Vector2(cityXPos, cityYPos);
                City newCity = new City(Model.Cities[i].name, cityPosition);
                if (Model.Distances.ContainsKey(Model.Cities[i].name))
                    Model.Distances[Model.Cities[i].name] = newCity;
                else
                    Model.Distances.Add(Model.Cities[i].name, newCity);
                Model.Cities[i].transform.position = Model.Distances[Model.Cities[i].name].Coordinates;
            }
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

