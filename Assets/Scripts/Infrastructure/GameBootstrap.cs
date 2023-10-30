using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        public AppCore AppCore;

        private void Awake()
        {
            AppCore = new AppCore();
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            AppCore.StateMachine.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            AppCore.StateMachine.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            AppCore.StateMachine.Update(Time.deltaTime);
        }
    }
}