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
        [SerializeField] private NavMeshAgent agent;

        private GameObject cubePool;
        private Vector3 destination;
        private bool targetCube = true;
        internal void Init()
        {
            cubePool = Managers.ObjectPooler.Instance.GetCreateObjectParent();
            agent.speed = _aiData.moveSpeed;
            agent.angularSpeed = _aiData.rotationSpeed;
            agent.acceleration = _aiData.acceleration;

            FindDestination();
        }

        private void Update()
        {
            agent.SetDestination(destination);

            if (Vector3.Distance(transform.position, destination) < _aiData.distanceBetweenDestination)
            {
                FindDestination();
            }
        }

        private void FindDestination()
        {
            Vector3 targetCubePos = Vector3.zero;

            if (cubePool.transform.childCount > 0)
            {
                targetCubePos = cubePool.transform.GetChild(Random.Range(0, cubePool.transform.childCount)).position;
            }

            destination = new Vector3(targetCubePos.x, transform.position.y, targetCubePos.z);
        }
    }
}
