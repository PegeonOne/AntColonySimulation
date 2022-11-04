using Colony.Ant.View;
using Colony.City.Map.Path;
using Colony.Core.Implementation;
using System.Collections.Generic;
using UnityEngine;

namespace Colony.Ant.Controller
{
    public class AntController : UnderViewController<AntView>
    {
        public override void OnControllerStart()
        {
            base.OnControllerStart();
            View = GetComponent<AntView>();
            View.VisitedCities.Add(View.StartCity);
            ChooseNextCity();
        }

        float t = 1;

        public override void OnControllerUpdate()
        {
            base.OnControllerUpdate();
            /*t -= Time.deltaTime * 0.7f;
            if(t <= 0)
            {
                if ((View.VisitedCities.Count) == View.Model.CityCount)
                {
                    View.AntFinish(distance, paths);
                }
                else ChooseNextCity();
                t = 1;
            }*/
        }

        float distance = 0;
        List<string> paths = new List<string>();
        private void ChooseNextCity()
        { 
            float value = Random.value;
            //this value for adding P, if pSum greater then value, ant chose this city
            float pSum = 0;
            for (int i = 0; i < View.Model.CityCount; i++)
            {
                if(!CheckVisitedCities("0" + i))
                {
                    PathView pathView = View.Model.Paths[View.StartCity + View.Model.CitiesID[i]];
                    float closeness = 20 / pathView.Model.distance;
                    float W = (Mathf.Pow(pathView.Model.pheromon, View.Model.PheromonInfluence) * 
                        Mathf.Pow(closeness, View.Model.ClosenessInfluence));
                    float P = (W) / (WSum());
                    pSum += P;
                    Debug.Log(View.Model.CitiesID[i] + " " + P);
                    /*if (pSum >= value)
                    {
                        View.StartCity = View.Model.CitiesID[i];
                        View.VisitedCities.Add(View.StartCity);
                        distance += pathView.Model.distance;
                        paths.Add(View.StartCity + View.Model.CitiesID[i]);
                        return;
                    }*/
                }               
            }
            
        }

        private float WSum()
        {
            float W = 0;
            for (int i = 0; i < View.Model.CityCount; i++)
            {
                if (!CheckVisitedCities("0" + i))
                {
                    PathView pathView = View.Model.Paths[View.StartCity + View.Model.CitiesID[i]];
                    float closeness = 20 /pathView.Model.distance;
                    W += (Mathf.Pow(pathView.Model.pheromon, View.Model.PheromonInfluence) *
                        Mathf.Pow(closeness, View.Model.ClosenessInfluence));
                }
            }
            return W;
        }

        private bool CheckVisitedCities(string id)
        {
            if (View.VisitedCities.Contains(id)) return true;
            else return false;
        }
    }
}

