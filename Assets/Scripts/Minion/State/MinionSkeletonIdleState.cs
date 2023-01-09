using Managers;

namespace Minion.State
{
    public class MinionSkeletonIdleState : MinionSkeletonBaseState
    {
        public override void EnterState(MinionSkeletonStateManager minionSkeleton)
        {
            LookForField(minionSkeleton);
        }

        public override void UpdateState(MinionSkeletonStateManager minionSkeleton)
        {
            if (minionSkeleton.Field != null && minionSkeleton.Field.State.IsEmpty)
            {
                minionSkeleton.Field.State.IsEmpty = false;
                minionSkeleton.SwitchState(minionSkeleton.LootState);
            }
            // else
            // {
            //     LookForField(minionSkeleton);
            // }
        }
        
        private static void LookForField(MinionSkeletonStateManager minionSkeleton)
        {
            minionSkeleton.Loot.SetActive(false);

            if (minionSkeleton.Field == null) minionSkeleton.Field = FieldManager.Instance.TryGetLootableField();

            minionSkeleton.MinionAnimationController.PlayMoveAnimation(0);
        }
    }
}