using Players;
using TMPro;
using UnityEngine;

namespace UI.Level
{
    [RequireComponent(typeof(TMP_Text))]
    public class AttemptsCountText : MonoBehaviour
    {
        [SerializeField] private Player _personage;

        private void Start() => 
            SetText();

        private void SetText()
        {
            TMP_Text textComponent = GetComponent<TMP_Text>();
            textComponent.text = _personage.AttemptsCount.ToString();
        }
    }
}