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
        UpdateDatasOnIterationFinished(dist, paths);
        if (View.AntsFinishedPaths == View.Model.AntCount)
        {
            //Recalculate pheromon on the path
            //Init next Iteration
            View.AntsFinishedPaths = 0;
            RecalculatePheromonsOnPaths();
            SpawnAnts();
        }
    }

    void RecalculatePheromonsOnPaths()
    {
        foreach (var key in View.Model.Paths.Keys)
        {
            PathModel NewPathModel = new PathModel();
            NewPathModel = View.Model.Paths[key].Model;
            NewPathModel.RebuildPath = true;
            NewPathModel.pheromon *= 0.6f;
            NewPathModel.pheromon += NewPathModel.pheromonCollectedOnIteration;
            View.Model.Paths[key].Model = NewPathModel;
        }
        View.Model.Iterations++;
    }

    float prevMinimumDist = 1000000;

    void UpdateDatasOnIterationFinished(float dist, List<string> paths)
    {
        View.Model.Iterations++;
        View.IterationText.text = View.Model.Iterations.ToString();
        if (dist < prevMinimumDist)
        {
            prevMinimumDist = dist;
            View.Model.MinimalDistance = dist;
            View.DistanceText.text = View.Model.MinimalDistance.ToString();
            foreach (var key in View.Model.Paths.Keys)
            {
                PathModel NewPathModel = new PathModel();
                NewPathModel = View.Model.Paths[key].Model;
                NewPathModel.RebuildPath = true;
                NewPathModel.color = new Color(0, 1, 1, 0);
                View.Model.Paths[key].Model = NewPathModel;
            }
            foreach (var key in paths)
            {
                PathModel NewPathModel = new PathModel();
                NewPathModel = View.Model.Paths[key].Model;
                NewPathModel.RebuildPath = true;
                NewPathModel.pheromonCollectedOnIteration += (View.Model.Q / prevMinimumDist);
                NewPathModel.color = new Color(0, 1, 1, 1);
                View.Model.Paths[key].Model = NewPathModel;  
            }
        }
        
    }

    #region ColonyInitilize
    private void OnColonyInit()
    {
        int cities = Int32.Parse(View.CityCountField.text);
        int ants = Int32.Parse(View.AntCountField.text);
        int alpha = Int32.Parse(View.AlphaInput.text);
        int betta = Int32.Parse(View.BettaInput.text);
        int q = Int32.Parse(View.Q.text);
        View.Model = new ColonyModel(ants, cities, betta, alpha, q, CreateCities());
        PlaceCities();
        GeneratePaths();
        SpawnAnts();
        View.SplashScreen.SetActive(false);
        View.InGameUI.SetActive(true);
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
            //View.Model.Ants.Add(view);
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
                view.Model = new PathModel(dist, View.Model.CitiesGameObjects[j], View.Model.CitiesGameObjects[k], dist, 0.05f, false);
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
            view.InitCity(i, cityPosition, View.Model, View.CitySprite);
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
