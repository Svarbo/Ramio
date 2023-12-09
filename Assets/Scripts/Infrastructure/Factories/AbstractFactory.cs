using UnityEngine;

namespace Infrastructure.Factories
{
    public class AbstractFactory
    {
        public T Create<T>(string prefabName) where T : Object =>
            Object.Instantiate(Resources.Load<T>(prefabName));

        // TODO метод не используется
        public T Create<T>(string prefabName, Vector3 position) where T : Object =>
            Object.Instantiate(Resources.Load<T>(prefabName), position, Quaternion.identity);
    }
}