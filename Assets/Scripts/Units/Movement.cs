using UnityEngine;
using UnityEngine.AI;


namespace Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        [SerializeField] private Transform targetTransform;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            //SetTarget(TryGetComponent(out AllyUnit allyUnit) ? allyUnit.transform.position : targetTransform.position);
        }

        public void SetTarget(Vector3 target)
        {
            _agent.SetDestination(target);
        }

        public void RoamToTarget()
        {
            SetTarget(targetTransform.position);
        }

        public Vector3 GetTargetPosition()
        {
            return targetTransform.position;
        }
    }
}
