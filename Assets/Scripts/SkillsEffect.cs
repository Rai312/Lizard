using UnityEngine;

[RequireComponent(typeof(ParticleController))]
public abstract class SkillsEffect : MonoBehaviour
{
    public abstract void ApplyFireAttackEffect();
}
