using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fan : MonoBehaviour
{
    [SerializeField] private FanPushZone _fanPushZone;
    [SerializeField] private bool _isActive;

    private Animator _animator;
    private int _isActiveParameter = Animator.StringToHash("IsActive");

    private void Start()
    {
        _animator = GetComponent<Animator>();

        DetermineWorkStatus();
    }

    private void DetermineWorkStatus()
    {
        if (_isActive)
            On();
        else
            Off();
    }

    private void On()
    {
        _fanPushZone.gameObject.SetActive(true);
        _animator.SetBool(_isActiveParameter, true);
    }

    private void Off()
    {
        _fanPushZone.gameObject.SetActive(false);
        _animator.SetBool(_isActiveParameter, false);
    }
}
