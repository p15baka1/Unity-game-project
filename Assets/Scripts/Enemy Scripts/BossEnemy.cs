using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Log
{
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySec;
    public bool canFire = true;

    private void Update()
    {
        if (canFire == false)
        {
            fireDelaySec -= Time.deltaTime;
            if (fireDelaySec <= 0)
            {
                canFire = true;
                fireDelaySec = fireDelay;
            }
        }
    }
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position)
    <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle
                || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                if (canFire)
                {
                    Vector3 tempVector = target.transform.position - transform.position;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().Launch(tempVector);
                    canFire = false;
                    ChangeState(EnemyState.walk);
                    anim.SetBool("wakeUp", true);
                }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
        else if (Vector3.Distance(target.position, transform.position)
   <= chaseRadius && Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            if (currentState == EnemyState.walk
                    && currentState != EnemyState.stagger)
            {
                StartCoroutine(AttackCo());
            }
        }
    }

    private IEnumerator AttackCo()
    {
        currentState = EnemyState.attack;
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(1f);
        currentState = EnemyState.walk;
        anim.SetBool("attack", false);
    }
}
