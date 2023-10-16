using System;
using Players;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class AnimatorPlayer : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private PlayerAnimationSetter _playerAnimationSetter;
        [SerializeField] private SpriteRenderer _playerSpriteRenderer;
        
        private void Start() =>
            _playerAnimationSetter.PlayDance(true);

        private void Update() =>
            _image.sprite = _playerSpriteRenderer.sprite;
    }
}