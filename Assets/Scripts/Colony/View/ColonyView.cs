using Colony.Models.ColonyModel;
using UnityEngine;
using UnityEngine.UI;
using Colony.Core.Implementation;
using System;

namespace Colony.City.UI.IniterView
{
    public class ColonyView : ViewWithModel<ColonyModel>
    {
        public Button InitButton;

        public InputField AntCountField;

        public InputField CityCountField;

        public InputField AlphaInput;

        public InputField BettaInput;

        public InputField Q;

        public Transform CitiesHolder;

        public Transform PathHolder;

        public Material LineMaterial;

        public GameObject SplashScreen;

        public GameObject InGameUI;

        public int AntsFinishedPaths;

        public Sprite CitySprite;

        public Text DistanceText;

        public Text IterationText;
    }       
}

