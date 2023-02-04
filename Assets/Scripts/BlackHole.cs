using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CC.BlackHole
{
    public class BlackHole : MonoBehaviour
    {
        [SerializeField] private float pullForce = 100.0f;
        [SerializeField] private float destroyTime = 2f;

        //private void OnTriggerEnter(Collider other)
        //{
        //    Debug.Log(other.tag);
        //    if (other.CompareTag("Cube"))
        //    {
        //    }
        //}

        internal void Call_PullMechanism(GameObject obj)
        {
        }

    }
}

