using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CC.Picker.Controller
{
    public class JoystickController : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private PlayerDataScriptableObject _playerData;

        private bool movementEnable = true;

        private Rigidbody rb;

        private Vector3 previousDirection, currentDirection;
        private Vector3 velocity = Vector3.zero;
        private float horizontalInput, verticalInput;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (!movementEnable)
                return;

            GetInputs();

            currentDirection = new Vector3(horizontalInput, 0, verticalInput);

            if (currentDirection != previousDirection && currentDirection.magnitude > 0)
            {
                Movement();

                Rotation();

                previousDirection = currentDirection;
            }
        }

        private void Rotation()
        {
            if (horizontalInput != 0 || verticalInput != 0)
                transform.rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, verticalInput));
        }

        private void Movement()
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, currentDirection * (_playerData.moveSpeed + _playerData.acceleration * (1/currentDirection.magnitude)), ref velocity, _playerData.moveSmoothness);
        }

        private void GetInputs()
        {
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
        }

        internal void StopMovement()
        {
            movementEnable = false;
        }
        internal void ActivateMovement()
        {
            movementEnable = true;
        }
    }
}
