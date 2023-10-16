using System.Collections;
using Agava.YandexGames;
using UnityEngine;

namespace SDK
{
    public class SDKInstantiator : MonoBehaviour
    {
        [SerializeField] private Sounds _sounds;

        private void Start()
        {
             _sounds.SetVolumeValues();
        }
    }
}
