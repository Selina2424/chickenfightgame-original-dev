using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState 
{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemy_Anim;
    private NavMeshAgent navAgent;

    private Transform playerTarget;

    public float move_Speed = 3.5f;

    public float attack_Distance = 1f;  //how close the ai goes to the player before attacking
    public float chase_Player_After_Attack_Distance = 1f;  //distance player is allowed to run before the AI starts attacking player or chasing 

    private float wait_Before_Attack_Time =3f;
    private float attack_Timer;

    private EnemyState enemy_State;

    public GameObject attackPoint;
    public GameObject attackPoint2;


    // First function called
    void Awake()
    {
        enemy_Anim = GetComponent<CharacterAnimations>(); //gets the components
        navAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform; //finds the game object with the player tag
    }

    void Start() 
    {
        enemy_State = EnemyState.CHASE;

        attack_Timer =wait_Before_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_State == EnemyState.CHASE) //If the enemy state is CHASE it will chase the player
        {
            ChasePlayer();
        }
        if(enemy_State == EnemyState.ATTACK) //If the enemy state is ATTACK it will attack the player
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position); //sets where the nav agent should go
        navAgent.speed = move_Speed; //sets the speed of the nav agent

        if(navAgent.velocity.sqrMagnitude == 0)
        {
            enemy_Anim.Walking(false); //wont walk if the square root magnitude is = to 0
        }
        else
        {
            enemy_Anim.Walking(true);
        }
        if(Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance) // measures if the range of player and enemy is within attack range
        {
            enemy_State = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero; //stops the nav mesh agent
        navAgent.isStopped = true;

        enemy_Anim.Walking(false); //stops walking animation

        attack_Timer += Time.deltaTime;

        if(attack_Timer > wait_Before_Attack_Time) //if the enemy can attack
        {
            if(Random.Range(0, 2) > 0)
            {
                enemy_Anim.AttackHitEnemy();
            }
            else
            {
                enemy_Anim.AttackHeadbuttEnemy();
            }
            attack_Timer = 0f; //resets attack timer to 0
        }
        if(Vector3.Distance(transform.position,playerTarget.position) > //if player is within chase distance chase player
            attack_Distance + chase_Player_After_Attack_Distance) //gives space for the player to start running away before it starts chasing
            {
                navAgent.isStopped = false; //enable navigation agent to move
                enemy_State = EnemyState.CHASE; //starts chasing player
            }
    }
    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
        attackPoint2.SetActive(true);
    }

    void Deactivate_AttackPoint()
    {
        if(attackPoint.activeInHierarchy) 
        {
            attackPoint.SetActive(false);
            attackPoint2.SetActive(false);
        }
    }
} //class
