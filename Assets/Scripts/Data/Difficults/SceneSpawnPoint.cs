using System;
using UnityEngine;

namespace Data.Difficults
{
    [Serializable]
    public struct SceneSpawnPoint
    {
        public int Id;
        public Vector3 Position;

        public SceneSpawnPoint(int id, Vector3 position)
        {
            Id = id;
            Position = position;
        }
    }
}