using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _prefab;

    private List<GameObject> _pool = new List<GameObject>();

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        for(int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(_prefab, transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }
}