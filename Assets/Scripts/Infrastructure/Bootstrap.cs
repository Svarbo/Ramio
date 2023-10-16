using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            Game game = new Game(this);
            DontDestroyOnLoad(this);
        }
    }
}