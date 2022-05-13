using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScaler : MonoBehaviour
{
    public void Scale()
    {
        transform.DOScale(1f, 2f);
    }
}
