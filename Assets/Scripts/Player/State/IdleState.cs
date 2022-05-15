using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LizardAnimationController))]
public class IdleState : State
{
    [SerializeField] private TongueAnimationController _tongueAnimationController;

    private LizardAnimationController _lizardAnimationController;

    private void Awake()
    {
        _lizardAnimationController = GetComponent<LizardAnimationController>();
    }

    private void OnEnable()
    {
        _tongueAnimationController.Idle();
        _lizardAnimationController.Idle();
    }
}
