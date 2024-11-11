using Extensions;
using UnityEngine;

namespace Bird.Birds
{
    public class BlackBird : BaseBird
    {
        [SerializeField] private CircleCollider2D col;
        private float _explosionForce = 3f;

        public override void Skill()
        {
            base.Skill();
            Rigidbody.AddExplosionForce(col, _explosionForce); //TODO подкрутить анимацию взрыва
        }
    }
}