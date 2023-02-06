using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.Cube
{
    public enum State
    {
        Free,
        CatchByPlayer,
        CatchByAI
    }
    public class Cube : MonoBehaviour
    {
        private Mechanics.CubePhysics cubePhysics;
        private Rigidbody rb;
        private State _state;
        private void Awake()
        {
            _state = State.Free;
            rb = GetComponent<Rigidbody>();
            cubePhysics = GetComponent<Mechanics.CubePhysics>();
        }
        private void FixedUpdate()
        {
            cubePhysics.ClampHeight(); // Prevent jump higher
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Picker"))
            {
                // Preserve fall from the picker

                cubePhysics.PushWithDirection(-collision.gameObject.transform.forward);
            }

            cubePhysics.PushOnGround(); // Prevent jump over the picker
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BlackHole")
                && (Managers.GameManager.Instance.gameMode != Managers.GameManager.GameMode.RivalAI || _state != State.Free))
            {
                // BlackHole Catch

                cubePhysics.CatchByBlackHole(other.gameObject, false);
            }
            else if (other.CompareTag("BlackHoleAI") && _state != State.Free)
            {
                // BlackHoleAI Catch

                cubePhysics.CatchByBlackHole(other.gameObject, true);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Picker"))
            {
                _state = State.CatchByPlayer;
                GetComponentInChildren<MeshCollider>().gameObject.layer = 3; //picker Collision layer
            }
            else if (other.CompareTag("PickerAI"))
            {
                _state = State.CatchByAI;
                GetComponentInChildren<MeshCollider>().gameObject.layer = 7; //ai Collision layer
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Picker") || other.CompareTag("PickerAI"))
            {
                _state = State.Free;
                GetComponentInChildren<MeshCollider>().gameObject.layer = 0; //Default Collision layer
            }
        }
    }
}

