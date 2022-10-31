using Colony.Models.ColonyModel;
using Colony.Models.Path;
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
        [SerializeField]
        GameObject Path;
        [SerializeField]
        Transform PathHolder;

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
            GeneratePaths(cities);
            gameObject.SetActive(false);
        }

        private void GeneratePaths(int cityCount)
        {
            int pathCount = cityCount * (cityCount - 1);
            for (int i = 0; i < pathCount; i++)
            {
                GameObject path = Instantiate(Path);
                path.transform.SetParent(PathHolder);
                PathView view = path.GetComponent<PathView>();
                Model.Paths.Add(i, view);
            }
            FillDefaultPathData();
        }

        private void FillDefaultPathData()
        {
            int cityChanger = 0;
            for (int j = 0; j < Model.CityCount; j++)
            {
                for (int k = 0; k < (Model.CityCount - 1); k++)
                {
                    float dist = Vector2.Distance(Model.Distances[Model.Cities[j].name].Coordinates, Model.Distances[Model.Cities[k].name].Coordinates);
                    Model.Paths[k + (j * (Model.CityCount - 1))].Model = new PathModel(dist, Model.Cities[j], Model.Cities[k], dist, 0.05f);
                    Model.Paths[k + (j * (Model.CityCount - 1))].CreatePath();
                }
                cityChanger += Model.CityCount;
            }
        }

        private void GenerateCities()
        {
            Vector2 maxSquare = new Vector2(11, 7f);
            Vector2 minSquare = new Vector2(-11, -5f);
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

