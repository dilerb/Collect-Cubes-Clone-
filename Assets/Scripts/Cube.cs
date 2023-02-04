using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.Cube
{
    public class Cube : MonoBehaviour
    {
        private Physics.CubePhysics cubePhysics;
        private Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            cubePhysics = GetComponent<Physics.CubePhysics>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            /* Prevent jump over the picker */

            cubePhysics.PushOnGround();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BlackHole"))
            {
                /* BlackHole Catch */

                cubePhysics.CatchByBlackHole(other.gameObject);
            }
        }
    }
}

