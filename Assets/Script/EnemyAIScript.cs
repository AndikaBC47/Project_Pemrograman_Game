using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    public NavMeshAgent agent_enemy;
    public Transform player;
    public LayerMask IsGround, IsPlayer;

    //patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange; //Seberapa jauh enemy bisa gerak

    //attack
    public float timeBetweenAttack;
    public bool attacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange; 
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent_enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, IsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, IsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            //Sentry mode
            sentry_enemy();
        }
        else if(playerInSightRange && !playerInAttackRange)
        {
            //Kejar Player
            chase_enemy();
        }
        else if(playerInSightRange && playerInAttackRange)
        {
            //Attack
            attack_enemy();
        }
    }

    private void sentry_enemy()
    {
        if (!walkPointSet)
        {
            searchWalkPoint();
        }

        if (walkPointSet)
        {
            agent_enemy.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Musuh sampai di titik
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, IsGround))
        {
            walkPointSet = true;
        }
    }

    private void chase_enemy()
    {
        agent_enemy.SetDestination(player.position);
    }
    
    private void attack_enemy()
    {
        agent_enemy.SetDestination(transform.position);

        transform.LookAt(player);

        if (!attacked)
        {
            attacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
