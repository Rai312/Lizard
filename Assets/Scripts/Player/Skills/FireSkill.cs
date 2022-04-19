using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
//using TMPro;


public class FireSkill : MonoBehaviour
{
    public event UnityAction ButtonClick;

    private void Update()
    {
        //Attack()//нужно проверка на дистанцию, а не update
    }

    //protected override void OnSkillButton()
    //{
    //    ButtonClick?.Invoke();
    //}

    //private void OnTriggerStay(Collider other)//тут наверно нужно IK добавить а не атаку и не тут это должно быть
    //{
    //    Debug.Log("OnTriggerStay");
    //    if (other.TryGetComponent<Enemy>(out Enemy enemy))
    //    {
    //        Attack(enemy);
    //    }
    //}

    public void Attack(Enemy enemy)//подумать нужно ли что то переавать в паблик 
    {
        //Debug.Log(Vector3.Distance(transform.position, enemy.transform.position));
        if (Vector3.Distance(transform.position, enemy.transform.position) < 15f)
        {
            Debug.Log("УРА");
            ButtonClick?.Invoke();
        }
    }    
}
