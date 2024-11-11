using UnityEngine;

namespace Bird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BaseBird : AbstractBird
    {
        protected Rigidbody2D Rigidbody { get; private set; }
        private bool _isSkillWasUsed = false;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.isKinematic = true;
        }

        // private void OnEnable()
        // {
        //     _playerInput.SkillActivated += Skill;
        // }
        //
        // private void OnDisable()
        // {
        //     _playerInput.SkillActivated -= Skill;
        // }

        private void Update() //fixme
        {
            if (_isSkillWasUsed)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Skill();
                _isSkillWasUsed = true;
            }
        }

        public override void Launch(Vector2 force)
        {
            Rigidbody.isKinematic = false;
            Rigidbody.velocity = (Vector2)Vector3.zero;
            Rigidbody.angularVelocity = 0f;
            Rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        // private void OnCollisionEnter2D(Collision2D other)
        // {
        //     if (other.gameObject.TryGetComponent<Pig>(out var pig))
        //     {
        //         OnBirdCollision?.Invoke(pig, other.relativeVelocity.magnitude);
        //     }
        // }
    }
}