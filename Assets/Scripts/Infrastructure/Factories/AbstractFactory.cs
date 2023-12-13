using UnityEngine;

namespace Infrastructure.Factories
{
    public class AbstractFactory
    {
        public T Create<T>(string prefabName) where T : Object =>
            Object.Instantiate(Resources.Load<T>(prefabName));
    }
}