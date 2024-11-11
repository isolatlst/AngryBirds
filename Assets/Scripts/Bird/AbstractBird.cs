using UnityEngine;

namespace Bird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class AbstractBird : MonoBehaviour
    {
        public abstract void Launch(Vector2 force);

        public virtual void Skill(){}
    }
}