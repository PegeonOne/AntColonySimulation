using Colony.Models.ColonyModel;
using Colony.Models.Path;
using Colony.City.Map.Path;
using Colony.City.View;
using System;
using UnityEngine;
using Colony.Core.Factory;
using Colony.Core.Implementation;
using Colony.City.UI.IniterView;
using Colony.Ant.View;
using System.Collections.Generic;

public class ColonyController : UnderViewController<ColonyView>
{
    Factory factory;
    public override void OnControllerStart()
    {
        base.OnControllerStart();
        factory = new Factory();
        View = GetComponent<ColonyView>();
        View.InitButton.onClick.AddListener(OnColonyInit);
    }

    void AntIterationFinished(float dist, List<string> paths)
    {
        View.AntsFinishedPaths++;
        if(View.AntsFinishedPaths == View.Model.AntCount)
        {
            UpdateDatasOnIterationFinished(dist, paths);
        }
    }

    void UpdateDatasOnIterationFinished(float dist, List<string> paths)
    {
        Debug.Log("Ant Finished path with dist - " +  dist);
        Debug.Log("Ant come thought out this way ");
        foreach (var item in paths)
        {
            Debug.Log(item);
        }
    }

    #region ColonyInitilize
    private void OnColonyInit()
    {
        int cities = Int32.Parse(View.CityCountField.text);
        int ants = Int32.Parse(View.AntCountField.text);
        View.Model = new ColonyModel(ants, cities, 4, 1, CreateCities());
        PlaceCities();
        GeneratePaths();
        SpawnAnts();
        View.SplashScreen.SetActive(false);
    }

    private void SpawnAnts()
    {
        for (int i = 0; i < View.Model.AntCount; i++)
        {
            int antSpawnCity = UnityEngine.Random.Range(0, View.Model.CityCount);
            GameObject ant = factory.CreateInstance<AntView>("ant " + i, View.Model.CityDatas[antSpawnCity].CityPosition, null);
            AntView view = ant.GetComponent<AntView>();
            view.Model = View.Model;
            view.StartCity = "0" + antSpawnCity.ToString();
            view.OnAntFinishedIteration += AntIterationFinished;
            View.Model.Ants.Add(view);
        }
    }

    private void GeneratePaths()
    {
        for (int j = 0; j < View.Model.CityCount; j++)
        {
            View.Model.CitiesID.Add("0" + j.ToString());
            for (int k = 0; k < View.Model.CityCount; k++)
            {
                if (j == k) continue;
                string key = ("0" + (j.ToString()) + "0" + (k.ToString()));
                GameObject path = factory.CreateInstance<PathView>(key, Vector2.zero, View.PathHolder);
                PathView view = path.GetComponent<PathView>();
                view.material = View.LineMaterial;
                float dist = Vector2.Distance(View.Model.CityDatas[j].CityPosition, View.Model.CityDatas[k].CityPosition);
                view.Model = new PathModel(dist, View.Model.CitiesGameObjects[j], View.Model.CitiesGameObjects[k], dist, 0.5f);
                View.Model.Paths.Add(key, view);
            }
        }

    }

    private void PlaceCities()
    {
        Vector2 maxSquare = new Vector2(11, 7f);
        Vector2 minSquare = new Vector2(-11, -5f);
        for (int i = 0; i < View.Model.CityCount; i++)
        {
            float cityXPos = UnityEngine.Random.Range(minSquare.x, maxSquare.x);
            float cityYPos = UnityEngine.Random.Range(minSquare.y, maxSquare.y);
            Vector2 cityPosition = new Vector2(cityXPos, cityYPos);
            CityView view = View.Model.CitiesGameObjects[i].GetComponent<CityView>();
            view.InitCity(i, cityPosition, View.Model);
            if (View.Model.CityDatas.ContainsKey(i)) View.Model.CityDatas[i] = view;
            else View.Model.CityDatas.Add(i, view);
        }
    }

    GameObject[] CreateCities()
    {
        int cityCount = Int32.Parse(View.CityCountField.text);
        GameObject[] array = new GameObject[cityCount];
        for (int i = 0; i < cityCount; i++)
        {
            GameObject city = factory.CreateInstance<CityView>(i.ToString(), Vector2.zero, View.CitiesHolder);
            city.GetComponent<CityView>().CityID = i;
            array[i] = city;
        }
        return array;
    }
    #endregion
}
