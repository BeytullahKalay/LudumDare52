namespace Minion.State
{
    public class MinionSkeletonMoveState : MinionSkeletonBaseState
    {
        public override void EnterState(MinionSkeletonStateManager minionSkeleton)
        {
            var desPos = GameManager.Instance.BaseBuild.position;
            var decreaseVector = (desPos - minionSkeleton.transform.position).normalized;
            minionSkeleton.Agent.SetDestination(desPos + decreaseVector * 3);
            minionSkeleton.MinionAnimationController.PlayMoveAnimation(1);
        }

        public override void UpdateState(MinionSkeletonStateManager minionSkeleton)
        {
            if (minionSkeleton.Agent.remainingDistance < 1f )
            {
                minionSkeleton.Loot.SetActive(false);
                minionSkeleton.CurrentLootTimeSeconds = 0;
                minionSkeleton.SwitchState(minionSkeleton.LootState);
            }
        }
    }
}
