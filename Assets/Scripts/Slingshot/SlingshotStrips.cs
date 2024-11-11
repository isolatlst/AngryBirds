using UnityEngine;


namespace Slingshot
{
    public class SlingshotStrips : AbstractSlingshot
    {
        [SerializeField] private AbstractSlingshot _origin;
        [SerializeField] private LineRenderer[] _stripsRenderers;
        [SerializeField] private Transform[] _stripsPositions;
        [SerializeField] private Transform _shotPosition;


        void Start()
        {
            for (int i = 0; i < _stripsRenderers.Length; i++)
            {
                _stripsRenderers[i].positionCount = 2;
                _stripsRenderers[i].SetPosition(0, _stripsPositions[i].position);
            }

            ResetStripsPositions();
        }

        public override void Shot()
        {
            _origin.Shot();
            ResetStripsPositions();
        }

        public override void ChangeTension(Vector2 startPos, Vector2 currentPos)
        {
            _origin.ChangeTension(startPos, currentPos);
            SetStripsPositions(_shotPosition.position);
        }

        private void ResetStripsPositions() => SetStripsPositions(_shotPosition.position);

        private void SetStripsPositions(Vector2 position)
        {
            for (int i = 0; i < _stripsRenderers.Length; i++)
            {
                _stripsRenderers[i].SetPosition(1, position);
            }
        }
    }
}