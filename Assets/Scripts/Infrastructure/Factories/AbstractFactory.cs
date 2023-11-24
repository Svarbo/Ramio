using UnityEngine;

public class AbstractFactory
{
    public T Create<T>(string prefabName) where T : Object =>
        Object.Instantiate(Resources.Load<T>(prefabName));

    public T Create<T>(string prefabName, Vector3 position) where T : Object =>
        Object.Instantiate(Resources.Load<T>(prefabName), position, Quaternion.identity);
}