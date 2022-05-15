using UnityEngine;

[RequireComponent(typeof(LizardAnimationController))]
public class MoveState : State
{
    [SerializeField] private TongueAnimationController _tongueAnimationController;

    private LizardAnimationController _lizardAnimationController;

    private void Awake()
    {
        _lizardAnimationController = GetComponent<LizardAnimationController>();
    }

    private void OnEnable()
    {
        _tongueAnimationController.Move();
        _lizardAnimationController.Move();
    }
}
