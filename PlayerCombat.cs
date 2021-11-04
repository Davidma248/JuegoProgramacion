using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    bool COMBO = false;

    public float attackRate = 2f;
    float nextAttack = 0f;

    void Update()
    {
        if(Time.time>=nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        if (COMBO == false)
        {
            animator.SetTrigger("Attack");
            COMBO = true;
        }
        else
        {
            animator.SetTrigger("COMBO");
            COMBO = false;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {     
            enemy.GetComponent<SLIME>().TakeDamage(2);
        }
    }   

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
