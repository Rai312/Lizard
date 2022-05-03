using UnityEngine;
using UnityEngine.UI;

public abstract class AttackSkill : MonoBehaviour
{
    [SerializeField] private LookAt _lookAt;
    [SerializeField] protected Button SkillButton;
    [SerializeField] protected TongueAnimationController TongueAnimationController;

    protected virtual void OnEnable()
    {
        _lookAt.TargetFound += OnTargetFound;
        _lookAt.TargetLost += OnTargetLost;
    }

    protected virtual void OnDisable()
    {
        _lookAt.TargetFound -= OnTargetFound;
        _lookAt.TargetLost -= OnTargetLost;
    }

    protected abstract void OnClickSkillButton();

    private void OnTargetFound()
    {
        SkillButton.onClick.AddListener(OnClickSkillButton);
    }

    private void OnTargetLost()
    {
        SkillButton.onClick.RemoveListener(OnClickSkillButton);
    }
}
