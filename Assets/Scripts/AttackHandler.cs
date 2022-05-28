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
                Attack(enemy, _iceSkill, _iceSkill.Damage);

                enemySkillsEffect.ApplyIceAttackEffect();
                
            }
            else if (_fireSkill.IsClicked)
            {
                Attack(enemy, _fireSkill, _fireSkill.Damage);

                enemySkillsEffect.ApplyFireAttackEffect();
                _playerSkillsEffect.ApplyFireAttackEffect();
            }
            else if (_poisonSkill.IsClicked)
            {
                Attack(enemy, _poisonSkill, _poisonSkill.Damage);

                enemySkillsEffect.ApplyPoisoningAttackEffect();
            }
        }
    }

    private void Attack(Enemy target, Skill skill, int damage)
    {
        target.DisableCollider();
        target.TakeDamage(damage);
        skill.DisactivateSkill();
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
