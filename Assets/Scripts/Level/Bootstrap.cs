using System.Collections.Generic;
using IJunior.TypedScenes;
using Infrastructure;
using Infrastructure.States.Scenes;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Curtain _curtain;

        private void Awake()
        {
            GameBootstrap boot = FindObjectOfType<GameBootstrap>();

            // if (boot.AppCore.SceneInstantiators.ContainsKey(SceneManager.GetActiveScene().name) == false)
            //     throw new KeyNotFoundException(SceneManager.GetActiveScene().name);

            // ItemSceneInitializer itemSceneInitializer = boot.AppCore.SceneInstantiators[SceneManager.GetActiveScene().name];
            // itemSceneInitializer.InstantiateObjects();

            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                boot.AppCore.StateMachine.Enter(typeof(Level1Scene));
               // Level1Initializer level1Initializer = Instantiate(Resources.Load<Level1Initializer>("ItemSceneInitializers/Level1Initializer"));
                //level1Initializer.InstantiateObjects();
                _curtain.Hide();
            }
            else
            {
                //Instantiate(Resources.Load<MainMenuInitializer>("ItemSceneInitializers/MainMenuInitializer"));
                boot.AppCore.StateMachine.Enter(typeof(MainMenuScene));
            }
        }
    }
}