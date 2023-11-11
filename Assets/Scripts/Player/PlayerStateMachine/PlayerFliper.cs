using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerFliper : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;

    private Transform _transform;
    private int _directionIndicator = 0;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _playerInfo.DirectionIndicatorChanged += SetFlip;
    }

    private void OnDisable()
    {
        _playerInfo.DirectionIndicatorChanged -= SetFlip;
    }

    private void SetFlip()
    {
        _directionIndicator = _playerInfo.DirectionIndicator;

        if (_directionIndicator > 0)
            _transform.rotation = Quaternion.Euler(Vector3.zero);
        else if (_directionIndicator < 0)
            _transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}