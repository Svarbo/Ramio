using Enemies;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class AbstractFactory
    {
        public T Create<T>(string prefabName) where T : Object =>
            Object.Instantiate(Resources.Load<T>( prefabName));
        
        // public T Create<T>(string prefabName, Vector3 position) where T : EnemyView =>
        //     Object.Instantiate(Resources.Load<T>("Enemy/Views/" + prefabName), position, Quaternion.identity);
        
        public T Create<T>(string prefabName, Vector3 position) where T : EnemyView =>
            Object.Instantiate(Resources.Load<T>(prefabName), position, Quaternion.identity);

        public T Load<T>(string prefabName) where T : Object =>
            Resources.Load<T>(prefabName);
    }
}