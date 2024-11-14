using UnityEngine;

namespace Slingshot
{
    [RequireComponent(typeof(LineRenderer))]
    public class Trajectory : MonoBehaviour
    {
        [SerializeField] private PlayerInput.PlayerInput _playerInput;
        private LineRenderer _lineRenderer;
        private const int MaxPoints = 50;
        private const float TimeInterval = .01f;
        
        private void OnEnable()
        {
            _playerInput.Released += ChangeActive;
            _playerInput.DisplayCursorDraged += DrawTrajectory;
        }
        private void OnDisable()
        {
            _playerInput.Released -= ChangeActive;
            _playerInput.DisplayCursorDraged -= DrawTrajectory;
        }
        
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void ChangeActive()
        {
            _lineRenderer.enabled = false;   
        }
        
        private void DrawTrajectory(Vector2 direction)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.positionCount = MaxPoints;
            var time = 0f;
            var startVelocity = Vector2.ClampMagnitude(direction, SlingshotParams.MaxDrag) * SlingshotParams.Power;
        
            for (var i = 0; i < MaxPoints; i++)
            {
                // s = v * t + .5 * g * t * t
                var x = (startVelocity.x * time) + (.5f * Physics2D.gravity.x * time * time);
                var y = (startVelocity.y * time) + (.5f * Physics2D.gravity.y * time * time);
                var point = new Vector2(x, y);
                _lineRenderer.SetPosition(i, point + (Vector2)transform.position);
                time += TimeInterval;
            }
        }
    }
}