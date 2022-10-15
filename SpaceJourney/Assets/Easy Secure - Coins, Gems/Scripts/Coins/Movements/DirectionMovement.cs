namespace MyApp.CoinsManager.Coins.Movement
{
    using UnityEngine;
    using UnityEngine.Events;


    public class DirectionMovement : MonoBehaviour
    {
        #region variable
        public Vector3 directionVector;
        public float speed = 20f;
        public bool enable = true;
        public UnityEvent onDestroyEvent;
        #endregion
        #region Function
        private void OnDestroy()
        {
            if (onDestroyEvent != null) onDestroyEvent.Invoke();
        }
        private void FixedUpdate()
        {
            if (!enable) return;
            Vector3 targetPosition = transform.position + (speed * Time.deltaTime) * directionVector;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        #endregion
    }
}