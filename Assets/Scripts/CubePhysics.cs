using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CC.Managers;

namespace CC.Cube.Mechanics
{
    public class CubePhysics : MonoBehaviour
    {
        [SerializeField] private CubeDataScriptableObject _cubeData;
        private Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        internal void CatchByBlackHole(GameObject bh,bool isAI)
        {
            StartCoroutine(Co_CatchByBlackHole(bh, isAI));
        }

        IEnumerator Co_CatchByBlackHole(GameObject bh, bool isAI)
        {
            //Change color

            GetComponentInChildren<MeshCollider>().gameObject.layer = 6; //Ignore Collision layer

            yield return transform.DOMove(bh.transform.position, _cubeData.blackHoleCatchDuration);
            yield return transform.DOScale(_cubeData.blackHoleMinimizeFactor, _cubeData.blackHoleCatchDuration).WaitForCompletion();
            CubeSpawner.Instance.DestroyObject(gameObject);

            if (isAI)
            {
                GameManager.Instance.IncreaseCollectedCubeCountByAI();
            }
            else
            {
                GameManager.Instance.IncreaseCollectedCubeCount();
            }
        }

        internal void PushOnGround()
        {
            rb.AddForce(Vector3.down * _cubeData.pushForceOnGround, ForceMode.Acceleration);
        }
        internal void PushWithDirection(Vector3 direction)
        {
            rb.AddForce(direction * _cubeData.pushForceDirection, ForceMode.Acceleration);
        }

        internal void ClampHeight()
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -0.5f, _cubeData.clampHeightValue), transform.position.z);
        }
    }
}

