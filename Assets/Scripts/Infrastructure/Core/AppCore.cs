using System;
using System.Collections.Generic;
using Infrastructure.StateMachines;
using Infrastructure.States;
using Infrastructure.States.Scenes;
using Level;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Core
{
    public class AppCore
    {
        private Dictionary<string, ItemSceneInitializer> _sceneInstantiators;

        public AppCore()
        {
            #region initSceneinitialize
            // _sceneInstantiators = new Dictionary<string, ItemSceneInitializer>()
            // {
            //     ["MainMenu"] = Object.Instantiate(Resources.Load<MainMenuInitializer>("ItemSceneInitializers/MainMenuInitializer")),
            //     ["Level0"] = Object.Instantiate(Resources.Load<Level1Initializer>("ItemSceneInitializers/Level1Initializer")) 
            // };
            #endregion
            
            Dictionary<Type, IState> scenes = new Dictionary<Type, IState>()
            {
                [typeof(MainMenuScene)] = new MainMenuScene(),
                [typeof(Level1Scene)] = new Level1Scene()
            };

            StateMachine = new StateMachine(scenes);
        }

        public IReadOnlyDictionary<string, ItemSceneInitializer> SceneInstantiators => _sceneInstantiators;
        public StateMachine StateMachine { get; }
    }
}