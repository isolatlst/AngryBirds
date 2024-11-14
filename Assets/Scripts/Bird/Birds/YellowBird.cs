using UnityEngine;

namespace Bird.Birds
{
    public class YellowBird : AbstractBaseBird
    {
        public override void Skill() 
        {
            base.Skill();
            Launch(Rigidbody.velocity * 1.5f);
        }
    }
}