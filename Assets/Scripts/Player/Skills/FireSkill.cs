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

    public void Attack(Enemy enemy)//подумать нужно ли что то переавать в паблик 
    {//подумать над названием метода
        //Debug.Log(Vector3.Distance(transform.position, enemy.transform.position));
        if (Vector3.Distance(transform.position, enemy.transform.position) < 15f)
        {
            Debug.Log("УРА");
            ButtonClick?.Invoke();
        }
    }    
}
