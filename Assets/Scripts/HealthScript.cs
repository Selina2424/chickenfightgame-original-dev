using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private CharacterAnimations dead_Anim;
    private float death_Time = 3f;
    public float health = 100f; //sets the objects health

    public bool isPlayer;

    [SerializeField] //makes the private health_UI visible
    private Image health_UI;

    void Awake() //first fuction called
    {
        dead_Anim = GetComponent<CharacterAnimations>(); //gets the components from the character animations script
    }

    
    

    public void ApplyDamage(float damage) //takes float damage as a parameter
    {
        health -= damage; //takes away damage from the health

        if (health_UI != null)
        {
            health_UI.fillAmount = health / 100f; //fills the health bar to how much health is left
        }

        if(health <=0)
        {
            
            StartCoroutine(AllowAnimation()); // strats the AllowAnimation function
            if (isPlayer)
            {
                GetComponent<PlayerMove>().enabled = false; //deactivates the player move script for player with 0 health
                GetComponent<PlayerAttackInput>().enabled = false; //deactivates the PlayerAttackInput script for player with 0 health

                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG)
                          .GetComponent<EnemyController>().enabled = false; //stops the enemy from trying to persue and attack the player
            }
            else
            {
                GetComponent<EnemyController>().enabled = false; //deactivates the EnemyController script for the enemy with 0 health
                GetComponent<NavMeshAgent>().enabled = false; //deactivates the NavMeshAgent for the enemy with 0 health

            }
        }
    }
    IEnumerator AllowAnimation()
    {
        dead_Anim.Dead(true);
        yield return new WaitForSeconds(death_Time); //waits a certain time before stopping animation
        dead_Anim.Dead(false);
    }
} //class
