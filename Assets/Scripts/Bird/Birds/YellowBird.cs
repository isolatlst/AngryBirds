using UnityEngine;

namespace Bird.Birds
{
    public class YellowBird : AbstractBaseBird
    {
        protected override void Skill() 
        {
            base.Skill();
            Launch(Rigidbody.velocity * 1.25f);
        }
    }
}