using UnityEngine;

namespace Slingshot
{
    [RequireComponent(typeof(LineRenderer))]
    public class SlingshotTrajectory : AbstractSlingshot
    {
        [SerializeField] private AbstractSlingshot _origin;
        [SerializeField] private Transform _idlePosition; //fixme dop
        [SerializeField] private Transform _shotPosition; //fixme dop
        private LineRenderer _lineRenderer;
        private int _maxPoints = 50;
        private float _timeInterval = .01f;
        private Vector2 _startVelocity;

        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public override void Shot()
        {
            _origin.Shot();
            _lineRenderer.enabled = false;
        }

        public override void ChangeTension(Vector2 startPosition, Vector2 currentPosition)
        {
            _origin.ChangeTension(startPosition, currentPosition);
            _lineRenderer.enabled = true;
            DrawTrajectory();
        }

        private void DrawTrajectory()
        {
            _lineRenderer.positionCount = _maxPoints;
            var time = 0f;
            _startVelocity = _idlePosition.position - _shotPosition.position;
            _startVelocity *= 8f; //fixme

            for (var i = 0; i < _maxPoints; i++)
            {
                // s = v * t + .5 * g * t * t
                var x = (_startVelocity.x * time) + (.5f * Physics2D.gravity.x * time * time);
                var y = (_startVelocity.y * time) + (.5f * Physics2D.gravity.y * time * time);
                var point = new Vector2(x, y);
                _lineRenderer.SetPosition(i, point + (Vector2)transform.position);
                time += _timeInterval;
            }
        }
    }
}