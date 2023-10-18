using UI;
using UnityEngine;

namespace Level
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Curtain _curtain;

        private void Awake()
        {
            _curtain.Hide();
        }
    }
}