using System.Collections.Generic;
using UnityEngine;

public class OrangesCounter : MonoBehaviour
{
    [SerializeField] private List<Orange> _oranges = new List<Orange>();

    private void Awake() =>
        PlayerPrefs.SetInt("CurrentLevelOrangesCount", _oranges.Count);
}