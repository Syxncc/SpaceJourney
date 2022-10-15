namespace MyApp.CoinsManager.Coins.Movement
{
    using UnityEngine;
    using UnityEngine.Events;


    public class TargetMovement : MonoBehaviour
    {
        #region variable
        public Vector2 targerPosition;
        public float hitDistance = .1f;
        public float speed = 20f;
        public bool enable = true;
        public UnityEvent onDestroyEvent;
        #endregion
        #region Function
        private void FixedUpdate()
        {
            if (!enable) return;
            if (Vector2.Distance(transform.position.toXY(), targerPosition) < hitDistance)
            {
                if (onDestroyEvent != null) onDestroyEvent.Invoke();
                Object.Destroy(this.gameObject);
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, targerPosition, speed * Time.deltaTime);
        }
        #endregion
        #region function
        public void autoSpeedlculate(int steps, float delaySecond)
        {
            if (steps == 0) return;
            var t = steps * delaySecond;
            if (t == 0) return;
            var distance = Vector2.Distance(transform.position.toXY(), targerPosition);
            this.speed = distance / t;
        }
        #endregion
    }
}