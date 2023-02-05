using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.Cube
{
    public class Cube : MonoBehaviour
    {
        private Mechanics.CubePhysics cubePhysics;
        private Rigidbody rb;
        private void Awake()
        {
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
            if (other.CompareTag("BlackHole"))
            {
                // BlackHole Catch

                GetComponentInChildren<MeshCollider>().gameObject.layer = 6; //Ignore Collision layer

                cubePhysics.CatchByBlackHole(other.gameObject);
            }
        }
    }
}

