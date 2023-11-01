using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimationSetter))]
public abstract class State : MonoBehaviour
{
    protected PlayerAnimationSetter PlayerAnimationSetter;

    private void Awake()
    {
        PlayerAnimationSetter = GetComponent<PlayerAnimationSetter>();
    }

    public void Enter()
    {
        enabled = true;
    }

    public void Exit()
    {
        enabled = false;
    }
}