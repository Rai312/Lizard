using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private HeadController _lookAt;
    [SerializeField] private int _damage;
    [SerializeField] protected Button SkillButton;
    [SerializeField] protected TongueAnimationController TongueAnimationController;
    [SerializeField] protected TongueMaterialChanger TongueMaterialChanger;

    public event UnityAction SkillButtonClick;

    public bool IsClicked { get; private set; }
    public int Damage => _damage;

    public void ActiveSkill()
    {
        IsClicked = true;
    }

    public void DisactivateSkill()
    {
        IsClicked = false;
    }

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
