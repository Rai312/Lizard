using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Update()
    {
        //MAGIC INT
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y + 10f, _target.transform.position.z);
    }
}
