using UnityEngine;

namespace Bird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class AbstractBaseBird : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody { get; private set; }
        private PlayerInput.PlayerInput _playerInput;
        private bool _isSkillBeenUsed;

        
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.isKinematic = true;
        }

        public void InitPlayerInput(PlayerInput.PlayerInput playerInput)
        {
            if (_playerInput != null)
                return;
            
            _playerInput = playerInput;
        }
        
        public void Launch(Vector2 force)
        {
            _playerInput.SkillWasActivated += Skill;
            Rigidbody.isKinematic = false;
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = 0f;
            Rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        protected virtual void Skill()
        {
            if(_isSkillBeenUsed || Rigidbody.velocity.magnitude <= 0f)
                return;
            
            _playerInput.SkillWasActivated -= Skill;
            _isSkillBeenUsed = true;
        }
    }
}