using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterAI : MonoBehaviour
{
    [Range(2,100)]
    public float DetectDistance = 10;
    public float distanceAttack = 3f;
    Vector3 initialpos;
    public SphereCollider colRight;
    public SphereCollider colLeft;
    Transform hero;
    bool canAttack = true;
    public NavMeshAgent agent;
    public MonsterMgr monsterMgr;

    private void Start()
    {
        initialpos = transform.position;
        hero = GameObject.Find("RPGHeroHP").transform;
        
    }

    private void Update()
    {
        if (monsterMgr.life > 0)
        {
            float distance = Vector3.Distance(transform.position, hero.position);

            if ((distance < DetectDistance) && (distance > distanceAttack))
            {
                agent.destination = hero.position;
            }
            if ((distance < distanceAttack) && canAttack)
            {
                canAttack = false;
                GetComponent<Animator>().SetTrigger("Attack");
                StartCoroutine("AttackPlayer");
            }
            if (distance > DetectDistance)
            {
                agent.destination = initialpos;
            }
        }
    }
    
    IEnumerator AttackPlayer()
    {
        colRight.enabled = true;
        colLeft.enabled = true;
        yield return new WaitForSeconds(1.2f);

        colRight.enabled = false;
        colLeft.enabled = false;
        yield return new WaitForSeconds(1.4f);

        canAttack = true;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectDistance);
    }
}
