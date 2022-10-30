using Colony.Models.ColonyModel;
using Colony.Views.Implementation;
using UnityEngine;
using UnityEngine.UI;


namespace Colony.Views.Map.View
{
    public class MapView : ViewWithModel<ColonyModel>
    {
        [SerializeField]
        private Button GenerateMap;

        protected override void OnStart()
        {
            base.OnStart();         
            GenerateMap.onClick.AddListener(OnGenerateClicked);
        }


        private void OnGenerateClicked()
        {
            Vector2 maxSquare = new Vector2(11, 7f);
            Vector2 minSquare = new Vector2(-11, -5f);
            for (int i = 0; i < Model.CityCount; i++)
            {
                float cityXPos = Random.Range(minSquare.x, maxSquare.x);
                float cityYPos = Random.Range(minSquare.y, maxSquare.y);
                Vector2 cityPosition = new Vector2(cityXPos, cityYPos);
                City newCity = new City(Model.Cities[i].name, cityPosition);
                if (Model.Distances.ContainsKey(Model.Cities[i].name))
                    Model.Distances[Model.Cities[i].name] = newCity; 
                else
                    Model.Distances.Add(Model.Cities[i].name, newCity);
                Model.Cities[i].transform.position = Model.Distances[Model.Cities[i].name].Coordinates;                
            }
        }

    }
}

