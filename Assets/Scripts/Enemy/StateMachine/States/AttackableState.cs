using System;
using UnityEngine;

public class AttackableState : State
{
    [SerializeField] private TransformableOfEnemy _transformableOfEnemy;
    [SerializeField] private Material _bodyMaterial;
    [SerializeField] private Color _targetColor;
    [SerializeField] private Color _startColor;//сделать потом ресет

    //public Color _startColor;//заприватить
    //1. эффект обледенения под ногами
    //1. эффект обледенения на враге-можно заранее сделать кубик и выключить

    //2. эффект желтого круга и искр, но на ящерице

    //3. эффект ядовитых облачков
    //3. враг зеленеет

    //Нужен еще передатчик какой скил был использован

    //если делается второй скил то уже меняется состояние ящерицы,
    //нужно машина состояний и для игрока или как?

    private void Awake()
    {
        _bodyMaterial.color = _startColor;
    }

    private void Start()
    {
        //Debug.Log("ApplyPoisoningEffect");
        ApplyPoisoningEffect();
    }
    
    //ВНИМАНИЕ Нужна корутина для 

    private void ApplyPoisoningEffect()
    {
        _bodyMaterial.color = _targetColor;
    }

    private void ApplyIceEffect()
    {
        _bodyMaterial.color = _targetColor;
    }

    private void ApplyFireEffect()
    {
        _bodyMaterial.color = _targetColor;
    }



    //со скила передается событие и оно переключает в нужный режим и этот режим ждет в событие attackHandler
    //и когда оно отрабатывает включается реализация удара по врагу
}
