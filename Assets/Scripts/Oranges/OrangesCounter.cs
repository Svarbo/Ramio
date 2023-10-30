using System.Collections.Generic;
using UnityEngine;

public class OrangesCounter : MonoBehaviour
{
    [SerializeField] private List<Orange> _oranges = new List<Orange>();

    public int TakeAllOrangesCount()
    {
        return _oranges.Count;
    }

    public int TakeCollectedOrangesCount()
    {
        int counter = 0;

        foreach(Orange orange in _oranges)
        {
            if(orange.gameObject.activeSelf == false)
                counter++;
        }

        return counter;
    }
}