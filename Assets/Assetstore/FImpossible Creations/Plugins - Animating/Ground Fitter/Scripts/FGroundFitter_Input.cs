using UnityEngine;

namespace FIMSpace.GroundFitter
{
    public class FGroundFitter_Input : FGroundFitter_InputBase
    {
        [SerializeField] private Joystick _joystick;

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) TriggerJump();

            Vector3 dir = Vector3.zero;

            if (_joystick.Direction.y > 0 || _joystick.Direction.x < 0 || _joystick.Direction.x > 0 || _joystick.Direction.y < 0)
            {
                //if (Input.GetKey(KeyCode.LeftShift)) Sprint = true; else Sprint = false;

                //if (Input.GetKey(KeyCode.W)) 
                if (_joystick.Direction.y > 0)
                {
                    //dir.z += 1f;
                    dir.z = _joystick.Direction.y;
                }
                //if (Input.GetKey(KeyCode.A)) 
                if (_joystick.Direction.x < 0)
                {
                    //dir.x -= 1f;
                    dir.x = _joystick.Direction.x;
                }
                //if (Input.GetKey(KeyCode.D)) 
                if (_joystick.Direction.x > 0)
                {
                    //dir.x += 1f;
                    dir.x = _joystick.Direction.x;
                }
                //if (Input.GetKey(KeyCode.S)) 
                if (_joystick.Direction.y < 0)
                {
                    //dir.z -= 1f;
                    dir.z = _joystick.Direction.y;
                }

                //dir.Normalize();

                RotationOffset = Quaternion.LookRotation(dir).eulerAngles.y;

                MoveVector = Vector3.forward;
            }
            else
            {
                Sprint = false;
                MoveVector = Vector3.zero;
            }

            //if (Input.GetKey(KeyCode.X)) MoveVector -= Vector3.forward;
            //if (Input.GetKey(KeyCode.Q)) MoveVector += Vector3.left;
            //if (Input.GetKey(KeyCode.E)) MoveVector += Vector3.right;

            MoveVector.Normalize();

            controller.Sprint = Sprint;
            controller.MoveVector = MoveVector;
            controller.RotationOffset = RotationOffset;
        }
    }
}