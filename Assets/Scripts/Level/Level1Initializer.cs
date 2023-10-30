using System;
using System.Collections.Generic;
using Enemies.TypeEnemies.Chameleons;
using UnityEngine;

namespace Level
{
    public class Level1Initializer : ItemSceneInitializer
    {
        [SerializeField] private List<Vector3> _chameleonPositions;

        private List<ChameleonPresenter> _chameleonPresenters = new List<ChameleonPresenter>();

        private void OnDestroy()
        {
            foreach (ChameleonPresenter chameleonPresenter in _chameleonPresenters)
            {
                chameleonPresenter.Dispose();
            }
        }

        private void FixedUpdate()
        {
            foreach (ChameleonPresenter chameleonPresenter in _chameleonPresenters)
                chameleonPresenter.Chameleon.StateMachine.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            foreach (ChameleonPresenter chameleonPresenter in _chameleonPresenters)
                chameleonPresenter.Chameleon.StateMachine.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            foreach (ChameleonPresenter chameleonPresenter in _chameleonPresenters)
                chameleonPresenter.Chameleon.StateMachine.LateUpdate(Time.deltaTime);
        }

        public override void InstantiateObjects() =>
            CreateChameleon();

        private void CreateChameleon()
        {
            foreach (Vector3 chameleonPosition in _chameleonPositions)
                _chameleonPresenters.Add(new ChameleonPresenter(chameleonPosition));
        }
    }
}