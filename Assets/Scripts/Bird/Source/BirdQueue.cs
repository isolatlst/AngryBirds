using System.Collections;
using Slingshot;
using UnityEngine;

namespace Bird.Source
{
    public class BirdQueue : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private PlayerInput.PlayerInput _playerInput;
        [SerializeField] private Shotpoint _shotpoint;
        [Header("Realisations")]
        [SerializeField] private BirdTransfer _birdTransfer;
        [SerializeField] private BirdSource _birdSource;

      
        private IEnumerator Start()
        {   
            for (var i = 0; i < _birdSource.BirdCount; i++)
            {   
                var bird = _birdSource.GetBird();
                bird.InitPlayerInput(_playerInput);
                yield return SeatBird(bird);
                yield return WaitShot();
            }
        }

        private IEnumerator SeatBird(AbstractBaseBird bird)
        {
            yield return _birdTransfer.Transfer(bird, _shotpoint.transform.position);
            _shotpoint.SetBird(bird);
        }

        private IEnumerator WaitShot()
        {
            _playerInput.Released += _shotpoint.Shot;
            
            while (_shotpoint.WasShooted == false)
            {
                yield return null;
            }
            
            _playerInput.Released -= _shotpoint.Shot;
        }
    }
}