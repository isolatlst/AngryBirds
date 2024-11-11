namespace Bird.Birds
{
    public class YellowBird : BaseBird
    {
        public override void Skill()
        {
            base.Skill();
            base.Launch(Rigidbody.velocity * 2f);
        }
    }
}