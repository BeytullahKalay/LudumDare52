namespace Minion.State
{
    public abstract class MinionSkeletonBaseState
    {
        public abstract void EnterState(MinionSkeletonStateManager minionSkeleton);

        public abstract void UpdateState(MinionSkeletonStateManager minionSkeleton);
    }
}
