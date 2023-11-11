using UnityEngine;
using UnityEngine.UI;

public class PlayerDance : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private SpriteRenderer _player;

    public void PlayDance()
    {
        //_playerAnimationSetter.PlayDance();
    }

    private void Update()
    {
        _image.sprite = _player.sprite;
    }
}