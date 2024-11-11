using UnityEngine;

namespace Slingshot
{
    public abstract class AbstractSlingshot : MonoBehaviour
    { 
        public abstract void Shot();
        public abstract void ChangeTension(Vector2 startPosition, Vector2 currentPosition);
    }
}