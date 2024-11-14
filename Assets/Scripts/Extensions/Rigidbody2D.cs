using System.Threading.Tasks;
using UnityEngine;

namespace Extensions
{
    public static class Rigidbody2DExplosion
    {
        public static async void AddExplosionForce(this Rigidbody2D rigidbody, CircleCollider2D col, float explosionForce)
        {
            var radius = col.radius;
            
            rigidbody.isKinematic = true;
            col.radius = radius * explosionForce;
            await Task.Delay(400);
           
            col.radius = radius;
            rigidbody.isKinematic = false;
        }
    }
}