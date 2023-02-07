using UnityEngine;
using UnityEngine.EventSystems;

namespace CC.Managers.Utility
{
    public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        private Vector2 startPos;
        private Vector2 direction;
        private Vector2 currentPos;

        public float horizontal;
        public float vertical;

        public void OnPointerDown(PointerEventData eventData)
        {
            startPos = eventData.position;
            currentPos = startPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            currentPos = eventData.position;
            direction = currentPos - startPos;

            horizontal = direction.x / Screen.width;
            vertical = direction.y / Screen.height;

            horizontal = Mathf.Clamp(horizontal, -1f, 1f);
            vertical = Mathf.Clamp(vertical, -1f, 1f);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            horizontal = 0;
            vertical = 0;
        }
    }
}
