using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class AttemptsCountText : MonoBehaviour
{
    [SerializeField] private Player _player;

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