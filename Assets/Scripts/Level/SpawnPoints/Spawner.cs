using UnityEngine;

namespace Level.SpawnPoints
{
    public class Spawner : MonoBehaviour
    {
        public Vector3 Position { get; private set; }

        private void Awake() =>
            Position = transform.position;
    }
}