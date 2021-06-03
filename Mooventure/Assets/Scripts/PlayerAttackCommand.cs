using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

namespace Player.Command
{
    public class PlayerAttackCommand : MonoBehaviour, IPlayerCommand 
    {
        private const float DURATION = 0.167f;
        public Animator Animator;
        public Transform AttackPoint;
        public float AttackRange = 0.7f;
        public LayerMask EnemyLayer;


        void Start()
        {
        }

        void Update()
        {
            
        }
        public void Execute(GameObject gameObject)
        {
            this.Animator = gameObject.GetComponent<Animator>();
            this.Animator.SetTrigger("Attack");
            this.AttackPoint = gameObject.transform.GetChild(0);
            this.EnemyLayer |= (1 << LayerMask.NameToLayer("Item"));

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.AttackPoint.position, this.AttackRange, this.EnemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
            }
        }

        void OnDrawGizmosSelected()
        {
            if (this.AttackPoint == null)
                return;

            Gizmos.DrawWireSphere(this.AttackPoint.position, this.AttackRange);
        }
    }
}
