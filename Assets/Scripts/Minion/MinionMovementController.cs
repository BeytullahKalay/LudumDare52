using System;
using FieldScripts;
using Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Minion
{
    
    [RequireComponent(typeof(NavMeshAgent))]

    public class MinionMovementController : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private Field _field;

        public Action GoBase;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        // private void Start()
        // {
        //     GoBase
        // }


        public void TryGetAField(MinionStateController minionStateController)
        {
            if (minionStateController.MinionState != MinionState.Idle) return;
            
            _field = FieldManager.Instance.GetLootableField();
            
            if(_field == null) return;

            _field.State.IsEmpty = false;
            
            _agent.SetDestination(_field.transform.position);

            minionStateController.MinionState = MinionState.Loot;
        }

        public void GoBaseToGiveLoot(bool isLooted, MinionStateController stateController,MinionLootController minionLootController)
        {
            if(!isLooted) return;

            stateController.MinionState = MinionState.Walk;

            var desPos = GameManager.Instance.BaseBuild.position;
            var decreaseVector = (desPos - transform.position).normalized;

            _agent.SetDestination(desPos + decreaseVector * 3);

            if (GetDistanceToTargetLocation() < .1f)
            {
                minionLootController.CurrentLootTimeSeconds = 0;
            }
        }

        public void TurnOwnField(MinionStateController stateController,MinionLootController minionLootController)
        {
            if (stateController.MinionState != MinionState.Loot) return;
            
            if(minionLootController.CurrentLootTimeSeconds != 0) return;
            
            _agent.SetDestination(_field.transform.position);

            if (GetDistanceToTargetLocation() < .1f)
            {
                stateController.MinionState = MinionState.Loot;
            }
        }

        public float GetSpeed()
        {
            return _agent.velocity.magnitude;
        }

        public float GetDistanceToTargetLocation()
        {
            return _agent.remainingDistance;
        }
        
        
    }
}
