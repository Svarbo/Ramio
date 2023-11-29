using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Curtain _curtain;

        private void Awake() =>
            _curtain.Hide();
    }
}