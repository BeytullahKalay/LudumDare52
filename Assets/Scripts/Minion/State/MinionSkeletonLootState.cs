using FieldScripts;
using Managers;
using UnityEngine;

namespace Minion.State
{
    public class MinionSkeletonLootState : MinionSkeletonBaseState
    {
        private Field _field;

        public override void EnterState(MinionSkeletonStateManager minionSkeleton)
        {
            if (_field == null) _field = FieldManager.Instance.TryGetLootableField();
            if (_field == null) return;

            _field.State.IsEmpty = false;

            minionSkeleton.Loot.SetActive(false);
        
            minionSkeleton.Agent.SetDestination(_field.transform.position);

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