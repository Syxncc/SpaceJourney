using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Profile", menuName="ScriptableObject/Profile")]
public class Profile : ScriptableObject
{
    public string name = "";
    public int playergold = 10000;
    public int playerbluegem = 1;
    public int playergreengem = 5;
    public int playerredgem = 10;
    public int playerLevel;

    public int currentMaxXP = 100;
    public int currentXP;

    public float jumpHeight = 0.7f;
    public float walkingSpeed = 10f;
    public float sprintingSpeed = 20f;
    public float regenCost = 5f;
    public float decreaseCostOvertime = 15f;
    public float jumpCost = 10f;
    public float maxStamina = 100f;

    // private int addMaxXP = 100;
    // private int tempXP;

    public float thrustBoosted = 3f;
    public float boostStaminaCost = 20f;
    public float firingStaminaCost = 30f;
}
