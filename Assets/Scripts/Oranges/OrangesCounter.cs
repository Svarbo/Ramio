using System.Collections.Generic;
using ConstantValues;
using UnityEngine;

namespace Oranges
{
    public class OrangesCounter : MonoBehaviour
    {
        [SerializeField] private List<Orange> _oranges = new List<Orange>();

        private void Awake() =>
            PlayerPrefs.SetInt(PlayerPrefsNames.CurrentLevelOrangesCount, _oranges.Count);
    }
}