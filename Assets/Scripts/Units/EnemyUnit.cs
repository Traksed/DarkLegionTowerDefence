using System;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Movement))]
    public class EnemyUnit : MonoBehaviour
    {
        [SerializeField] private int hitPoints;
        [SerializeField] private int attackDamage;
        [SerializeField] private int attackRange;
        [SerializeField] private int visionRange;
        [SerializeField] private LayerMask allyLayer;
        
        private enum State
        {
            Roaming,
            Fight,
        }

        private State _state;
        private Movement _movement;
        private AllyUnit _targetEnemy;
        private Vector3 _targetPosition;
       

        private void Awake()
        {
            _state = State.Roaming;
            _movement = GetComponent<Movement>();
        }

        private void Start()
        {
            _targetPosition = _movement.GetTargetPosition();
        }

        private void Update()
        {
            switch (_state)
            {
                default:
                    case State.Roaming:
                    if (Vector3.Distance(transform.position, _targetPosition) > attackRange)
                    {
                        _movement.RoamToTarget();
                        Debug.Log("Roam To Target");
                    }
                    break;
                case State.Fight:
                    
                    break;
            }
        }

        public void TakeDamage(int amount)
        {
            hitPoints -= amount;
            if (hitPoints <= 0)
            {
                OnDeath();
            }
        }

        public void Attack(AllyUnit enemy)
        {
            enemy.TakeDamage(attackDamage);
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}
