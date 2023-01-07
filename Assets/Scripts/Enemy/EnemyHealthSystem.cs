using AbstractClasses;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealthSystem : HealthSystem
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage?.Invoke(50);
            }
        }
    }
}