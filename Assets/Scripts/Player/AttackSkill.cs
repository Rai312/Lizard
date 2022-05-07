using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class AttackSkill : MonoBehaviour
{
    [SerializeField] private LookAt _lookAt;
    [SerializeField] private int _damage;
    [SerializeField] protected Button SkillButton;
    [SerializeField] protected TongueAnimationController TongueAnimationController;

    //protected bool IsClick;
    public bool IsClicked { get; private set; }
    public int Damage => _damage;
    public event UnityAction SkillButtonClick;

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

    protected virtual void OnClickSkillButton()
    {
        SkillButtonClick?.Invoke();
        //Debug.Log(_isClick);
    }

    public void ActiveSkill()
    {
        IsClicked = true;
    }

    public void DisactivateSkill()
    {
        IsClicked = false;
    }

    private void OnTargetFound()
    {
        SkillButton.onClick.AddListener(OnClickSkillButton);
    }

    private void OnTargetLost()
    {
        SkillButton.onClick.RemoveListener(OnClickSkillButton);
    }
}
