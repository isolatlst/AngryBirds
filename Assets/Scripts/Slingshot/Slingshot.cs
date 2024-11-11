using System.Collections;
using System.Collections.Generic;
using Bird;
using Bird.Source;
using UnityEngine;

namespace Slingshot
{
    public class Slingshot : AbstractSlingshot
    {
        [SerializeField] private PlayerInput.PlayerInput _playerInput;
        [SerializeField] private BirdSource _birdSource;
        [SerializeField] private BirdTransfer _birdTransfer;
        [SerializeField] private Transform _idlePosition;
        private AbstractBird _bird;
        private readonly float _power = 8f;
        private readonly float _maxDrag = 2f;
        private Vector2 _direction;
        private bool _wasShooted;

        
        private IEnumerator Start()
        {   
            for (var i = 0; i < 3; i++)
            {   
                _wasShooted = false;
                _bird = _birdSource.GetBird();
                yield return SeatBird(_bird);
                yield return WaitShot();
            }
        }

        private IEnumerator SeatBird(AbstractBird bird)
        {
            this.enabled = false;
            yield return _birdTransfer.Transfer(bird, transform.position);
            this.enabled = true;
        }
        
        public override void ChangeTension(Vector2 startPos, Vector2 currentPos)
        {
            _direction = Vector2.ClampMagnitude((startPos - currentPos), _maxDrag);
            transform.position = -(Vector3)_direction + _idlePosition.position;
            _bird.transform.position = transform.position;
        }

        private IEnumerator WaitShot()
        {
            _playerInput.Released += Shot;
            
            while (_wasShooted == false)
            {
                yield return null;
            }
            
            _playerInput.Released -= Shot;
        }
        public override void Shot()
        {
            if (_direction.magnitude * _power > 1f)
            {
                _bird.Launch(_direction * _power);
                _wasShooted = true;
            }
        }
    }
}