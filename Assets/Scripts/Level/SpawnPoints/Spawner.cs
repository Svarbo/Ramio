using UnityEngine;

namespace Level.SpawnPoints
{
    public class Spawner : MonoBehaviour
    {
        [field: SerializeField] public Transform Position { get; private set; }
    }
}