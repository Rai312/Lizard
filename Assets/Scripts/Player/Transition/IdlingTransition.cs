using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingTransition : Transition
{
    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        if (_joystick.Direction.x == 0 && _joystick.Direction.y == 0)
        {
            Debug.Log("IdlingTransition");
            NeedTransit = true;
        }
    }
}
