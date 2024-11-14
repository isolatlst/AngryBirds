using Bird;
using UnityEngine;

namespace Slingshot
{
    public class Shotpoint : MonoBehaviour
    {
        [SerializeField] private PlayerInput.PlayerInput _playerInput;
        [SerializeField] private Transform _idlePosition;
        public bool WasShooted { get; private set; }
        private AbstractBaseBird _bird;
        private Vector2 _direction;


        private void ChangeTension(Vector2 direction)
        {
            _direction = Vector2.ClampMagnitude(direction, SlingshotParams.MaxDrag);
            transform.position = -(Vector3)_direction + _idlePosition.position;
            _bird.transform.position = transform.position;
        }

        public void SetBird(AbstractBaseBird bird)
        {
            WasShooted = false;
            _playerInput.DisplayCursorDraged += ChangeTension;
            _bird = bird;
        }

        public void Shot()
        {
            if (_direction.magnitude * SlingshotParams.Power > 1f)
                _bird.Launch(_direction * SlingshotParams.Power);

            WasShooted = true;
            transform.position = _idlePosition.position;
            _playerInput.DisplayCursorDraged -= ChangeTension;
        }
    }
}