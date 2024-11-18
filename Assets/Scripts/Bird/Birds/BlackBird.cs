using System.Threading.Tasks;
using Extensions;
using UnityEngine;

namespace Bird.Birds
{
    public class BlackBird : AbstractBaseBird
    {
        [SerializeField] private CircleCollider2D col;
        [SerializeField] private ParticleSystem _explosionTemplate;
        private const float ExplosionForce = 3f;


        protected override async void Skill()
        {
            base.Skill();
            var explosion = Instantiate(_explosionTemplate, transform);
            await Task.Delay(200);
            Rigidbody.AddExplosionForce(col, ExplosionForce); 
            Destroy(explosion);
        }
    }
}