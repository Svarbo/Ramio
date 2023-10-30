using UnityEngine;

namespace Enemies
{
    public class EnemyViewFactory
    {
        public T Create<T>(string prefabName) where T : EnemyView =>
            Object.Instantiate(Resources.Load<T>("Enemy/Views/" + prefabName));
        
        public T Create<T>(string prefabName, Vector3 position) where T : EnemyView =>
            Object.Instantiate(Resources.Load<T>("Enemy/Views/" + prefabName), position, Quaternion.identity);
    }
}