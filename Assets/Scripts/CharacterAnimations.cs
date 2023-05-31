using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator Anim;
    //first function called
    void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    public void Walking(bool walking) //sets animatiom for walking to take a boolean parameter
    {
        Anim.SetBool(AnimationTags.WALKING_PARAMETER, walking); //sets the 'Walking' value to the boolean 'walking' value
    }

    public void  AttackHit(bool attackhit)
    {
        Anim.SetBool(AnimationTags.ATTACK_HIT_PARAMETER, attackhit);
    }

    public void  AttackHeadbutt(bool headbutt)
    {
        Anim.SetBool(AnimationTags.ATTACK_HEADBUTT_PARAMETER, headbutt);
    }

    public void AttackHitEnemy()
    {
        Anim.SetTrigger(AnimationTags.ATTACK_HEADBUTT_ENEMY_INT);
    }

    public void AttackHeadbuttEnemy()
    {
        Anim.SetTrigger(AnimationTags.ATTACK_HIT_ENEMY_INT);
    }

    public void Dead(bool dead)
    {
        Anim.SetBool(AnimationTags.DEAD, dead);
    }
} //class
