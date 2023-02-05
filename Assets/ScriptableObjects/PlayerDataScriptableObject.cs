using UnityEngine;

namespace CC
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerDataScriptableObject", order = 1)]
    public class PlayerDataScriptableObject : ScriptableObject
    {
        public float moveSpeed = 10.0f;
        public float rotationSpeed = 5.0f;
        public float acceleration = 5.0f;
        public float moveSmoothness = 0.3f;
    }
}
