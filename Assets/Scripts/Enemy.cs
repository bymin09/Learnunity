using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform player;
    Animator animator;
    public bool isAttackCheck = false;
    int maxHp = 2;
    int hp = 2;
    bool isStop = false;
    Renderer[] renderers;
    Color originColor;

    bool isWalk = false;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        navMeshAgent.destination = player.position;

        renderers = this.GetComponentsInChildren<Renderer>();
        originColor = renderers[0].material.color;
    }

    
    void Update()
    {
        Walk();

        if(!navMeshAgent.isStopped)
        {
            if (Vector3.Distance(this.transform.position, player.position) < navMeshAgent.stoppingDistance + 0.1f)
            {
                isWalk = false;
                navMeshAgent.isStopped = true;
                StartCoroutine("Attack");
            }
            else
            {
                isWalk = true;
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = player.position;
            }
        }

        // this.transform.LookAt(player.position);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("isAttack");
        yield return new WaitForSeconds(0.5f);
        if(Vector3.Distance(this.transform.position, player.position) < navMeshAgent.stoppingDistance + 0.1f){
            StartCoroutine("Attack");
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
    }
    
    void Walk()
    {
        if (isWalk == true)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }

    public void SetHp(int damage)
    {
        if (!isStop)
        {
            hp -= damage;
            if(hp <= 0)
            {
                hp = 0;
                animator.SetTrigger("Death");
                isAttackCheck = false;
                isStop = true;
                navMeshAgent.isStopped = true;
            }
            else
            {
                StartCoroutine("HitColor");
            }
        }
    }

    IEnumerator HitColor()
    {
        foreach(Renderer render in renderers)
        {
            // render.material.color = render.material.color * hp / maxHp;
            render.material.color = Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        foreach(Renderer render in renderers)
        {
            // render.material.color = render.material.color * hp / maxHp;
            render.material.color = originColor;
        }
    }
}
