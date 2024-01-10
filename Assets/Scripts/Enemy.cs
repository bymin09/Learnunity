using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMeshAgent;
    Transform player;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        navMeshAgent.destination = player.position;
    }

    
    void Update()
    {
        if(!navMeshAgent.isStopped)
        {
            if (Vector3.Distance(this.transform.position, player.position) < navMeshAgent.stoppingDistance + 0.1f)
            {
                navMeshAgent.isStopped = true;
                StartCoroutine("Attack");
            }
            else
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = player.position;
            }
        }

        this.transform.LookAt(player.position);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("isAttack");
        yield return new WaitForSeconds(0.5f);
        if(Vector3.Distance(this.transform.position, player.position) < navMeshAgent.stoppingDistance + 0.1f){
            StartCoroutine("Attack");
            //Attack 실행오류 고치기
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
    }
}
