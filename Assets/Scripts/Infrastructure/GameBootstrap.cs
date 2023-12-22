using Infrastructure.Core;
using Transitions;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private Fader _fader;

        public AppCore AppCore { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (AppCore is null)
                AppCore = new AppCore(this, _fader);
        }
    }
}