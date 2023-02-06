using UnityEngine;

namespace CC
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AIDataScriptableObject", order = 1)]
    public class AIDataScriptableObject : ScriptableObject
    {
        public float moveSpeed = 10.0f;
        public float rotationSpeed = 5.0f;
        public float acceleration = 5.0f;
        public float distanceBetweenDestination = 1f;
    }
}
