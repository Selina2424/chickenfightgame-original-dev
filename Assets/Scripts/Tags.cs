using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Axis 
{
    public const string VERTICAL_AXIS = "Vertical";  //constant makes it so value cant be changed
    public const string HORIZONTAL_AXIS = "Horizontal";
}

public class Tags
{
    public const string PLAYER_TAG = "PlayerCharacter";
    public const string ENEMY_TAG = "Enemyarm";
}

public class AnimationTags
{
    public const string WALKING_PARAMETER = "Walking";
    public const string ATTACK_HIT_PARAMETER = "AttackHit";
    public const string ATTACK_HEADBUTT_PARAMETER = "AttackHeadbutt";
    public const string ATTACK_HEADBUTT_ENEMY_INT = "AttackHeadbuttEnemy";
    public const string ATTACK_HIT_ENEMY_INT = "AttackHitEnemy";
    public const string DEAD = "Dead";
}
