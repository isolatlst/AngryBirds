using UnityEngine;


namespace Slingshot
{
    [RequireComponent(typeof(LineRenderer))]
    public class Strip : MonoBehaviour
    {
        [SerializeField] private Transform _shotPointPosition;
        private LineRenderer _lineRenderer;
        private const int PointsCount = 2;
        private const int StartPoint = 0;
        private const int EndPoint = 1;


        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = PointsCount;
            _lineRenderer.SetPosition(StartPoint, transform.position);
        }

        private void Update()
        {
            _lineRenderer.SetPosition(EndPoint, _shotPointPosition.position);
        }
    }
}