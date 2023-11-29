using Player;
using TMPro;
using UnityEngine;

namespace UI.Level
{
    [RequireComponent(typeof(TMP_Text))]
    public class AttemptsCountText : MonoBehaviour
    {
        [SerializeField] private MainHero _player;

        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();

            SetText();
        }

        private void SetText()
        {
            _text.text = _player.AttemptsCount.ToString();
        }
    }
}