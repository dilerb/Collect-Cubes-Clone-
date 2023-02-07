using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CC.AI.Controller
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private AIDataScriptableObject _aiData;
        [SerializeField] private GameObject blackHole;
        //[SerializeField] private NavMeshAgent agent;

        private GameObject cubePool;
        private Vector3 destination;
        private bool targetCube = true;
        private bool movementEnable = true;
        private Rigidbody rb;
        internal void Init()
        {
            rb = GetComponent<Rigidbody>();
            cubePool = Managers.ObjectPooler.Instance.GetCreateObjectParent();
            FindDestination();
        }

        private void Update()
        {
            if (!movementEnable)
                return;

            AIMovement();

            AIRotation();

            if (Vector3.Distance(transform.position, destination) < _aiData.distanceBetweenDestination)
            {
                FindDestination();
            }
        }

        private void AIMovement()
        {
            rb.velocity = (destination - transform.position).normalized * _aiData.moveSpeed;
            //transform.position = Vector3.MoveTowards(transform.position, destination, _aiData.moveSpeed * Time.deltaTime);
        }

        private void AIRotation()
        {
            transform.LookAt(destination);
        }

        private void FindDestination()
        {
            if(targetCube)
            {
                Vector3 targetCubePos = Vector3.zero;

                if (cubePool.transform.childCount > 0)
                {
                    targetCubePos = cubePool.transform.GetChild(Random.Range(0, cubePool.transform.childCount)).position;
                }

                destination = new Vector3(targetCubePos.x, transform.position.y, targetCubePos.z);

                if (Random.Range(0, 2) == 0) // Collect another cube possibility
                    targetCube = false;
            }
            else
            {
                destination = new Vector3(blackHole.transform.position.x, transform.position.y, blackHole.transform.position.z);

                targetCube = true;
            }
        }

        internal void StopMovement()
        {
            movementEnable = false;
        }
    }
}
