using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{   
    private CharacterAnimations playerAnimations;

    public GameObject attackPoint;
    public GameObject attackPoint2;

    // First function called
    void Awake()
    {
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) //plays the AttackHit animation when player presses left mouse button
        {
            playerAnimations.AttackHit(true);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0)) //stops the AttackHit animation when the player releases left mouse button
        {
            playerAnimations.AttackHit(false);
        }

        if(Input.GetKeyDown(KeyCode.Q)) //plays the AttackHeadbutt animation when player presses Q
        {
            playerAnimations.AttackHeadbutt(true);
        }

        if(Input.GetKeyUp(KeyCode.Q)) //stops the AttackHeadbutt animation when the player releases Q 
        {
            playerAnimations.AttackHeadbutt(false);
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
