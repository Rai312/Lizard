using UnityEngine;
using UnityEngine.Events;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private PlayerSkillsEffect _playerSkillsEffect;
    [SerializeField] private IceSkill _iceSkill;
    [SerializeField] private FireSkill _fireSkill;
    [SerializeField] private PoisonSkill _poisonSkill;

    public event UnityAction Attacked;

    private void OnEnable()
    {
        _iceSkill.SkillButtonClick += OnIceSkillButtonClick;
        _fireSkill.SkillButtonClick += OnFireSkillButtonClick;
        _poisonSkill.SkillButtonClick += OnPoisonSkillButtonClick;
    }

    private void OnDisable()
    {
        _iceSkill.SkillButtonClick -= OnIceSkillButtonClick;
        _fireSkill.SkillButtonClick -= OnFireSkillButtonClick;
        _poisonSkill.SkillButtonClick -= OnPoisonSkillButtonClick;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<Enemy>(out Enemy enemy)
            && other.TryGetComponent<EnemySkillsEffect>(out EnemySkillsEffect enemySkillsEffect))
        {
            Attacked?.Invoke();
            
            if (_iceSkill.IsClicked)
            {
                enemy.DisableCollider();
                enemy.TakeDamage(_iceSkill.Damage);
                enemySkillsEffect.ApplyIceAttackEffect();
                _iceSkill.DisactivateSkill();
            }
            else if (_fireSkill.IsClicked)
            {
                enemy.DisableCollider();
                enemy.TakeDamage(_fireSkill.Damage);
                enemySkillsEffect.ApplyFireAttackEffect();
                _playerSkillsEffect.ApplyFireAttackEffect();
                _fireSkill.DisactivateSkill();
            }
            else if (_poisonSkill.IsClicked)
            {
                enemy.DisableCollider();
                enemy.TakeDamage(_poisonSkill.Damage);
                enemySkillsEffect.ApplyPoisoningAttackEffect();
                _poisonSkill.DisactivateSkill();
            }
        }
    }
    private void OnIceSkillButtonClick()
    {
        _iceSkill.ActiveSkill();
    }

    private void OnFireSkillButtonClick()
    {
        _fireSkill.ActiveSkill();
    }

    private void OnPoisonSkillButtonClick()
    {
        _poisonSkill.ActiveSkill();
    }
}
