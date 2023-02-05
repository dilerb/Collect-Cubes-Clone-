using UnityEngine;

namespace CC
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CubeDataScriptableObject", order = 1)]
    public class CubeDataScriptableObject : ScriptableObject
    {
        public float clampHeightValue = 1f;
        public float pushForceOnGround = 100.0f;
        public float pushForceDirection = 100.0f;
        public float blackHoleCatchDuration = 0.5f;
        public float blackHoleMinimizeFactor = 0.5f;
    }
}
