using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CC.Cube.Physics
{
    public class CubePhysics : MonoBehaviour
    {
        [SerializeField] private float clampHeightValue = 1f;
        [SerializeField] private float pushForceOnGround = 100.0f;
        [SerializeField] private float blackHoleCatchDuration = 0.5f;
        [SerializeField] private float blackHoleMinimizeFactor = 0.5f;

        private Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        internal void CatchByBlackHole(GameObject bh)
        {
            StartCoroutine(Co_CatchByBlackHole(bh));
        }
        IEnumerator Co_CatchByBlackHole(GameObject bh)
        {
            //Change color
            //ignore collision
            yield return transform.DOMove(bh.transform.position, blackHoleCatchDuration);
            yield return transform.DOScale(blackHoleMinimizeFactor, blackHoleCatchDuration).WaitForCompletion();
            Destroy(gameObject);
            //Destroy object pooling
        }

        internal void PushOnGround()
        {
            rb.AddForce(Vector3.down * pushForceOnGround, ForceMode.Acceleration);
        }

        internal void ClampHeight()
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, clampHeightValue), transform.position.z);
        }
    }
}

