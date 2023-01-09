using UnityEngine;

namespace Minion.State
{
    public class MinionSkeletonLootState : MinionSkeletonBaseState
    {
        public override void EnterState(MinionSkeletonStateManager minionSkeleton)
        {
            minionSkeleton.Loot.SetActive(false);
        
            minionSkeleton.Agent.SetDestination(minionSkeleton.Field.transform.position);

            minionSkeleton.MinionAnimationController.PlayMoveAnimation(1);
        }

        public override void UpdateState(MinionSkeletonStateManager minionSkeleton)
        {
            if (minionSkeleton.CurrentLootTimeSeconds >= minionSkeleton.NeedLootTimeSeconds)
            {
                minionSkeleton.Loot.SetActive(true);
                minionSkeleton.MinionAnimationController.StopLootAnimation();
                minionSkeleton.SwitchState(minionSkeleton.TransferState);
            }
            else if (minionSkeleton.Agent.remainingDistance < .1f)
            {
                minionSkeleton.CurrentLootTimeSeconds += Time.deltaTime;
                minionSkeleton.MinionAnimationController.PlayLootAnimation();
            }
        }
    }
}