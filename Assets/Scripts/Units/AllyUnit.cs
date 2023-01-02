using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Movement))]
    public class AllyUnit : MonoBehaviour
    {
        [SerializeField] private int hitPoints;
        [SerializeField] private int attackDamage;
        [SerializeField] private int attackRange;
        [SerializeField] private int visionRange;
        [SerializeField] private LayerMask enemyLayer;

        private Movement _movement;
        private EnemyUnit _targetEnemy;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
        }

        private void Update()
        {
            
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
