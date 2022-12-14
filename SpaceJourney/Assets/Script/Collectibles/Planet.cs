using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObject/Collectible/Planet")]
public class Planet : Collectible
{
    public int planetScene;
    [System.Serializable]
    public class PlanetRequirement
    {
        public int walk;
        public int sprint;
        public int jump;
        public int sprintStamina;
        public int jumpStamina;
        public int spaceshipBoost;
        public int spaceshipSpeed;
        public int spaceshipBulletOverheating;
        public Collectible[] collectibles;

    }

    public PlanetRequirement planetRequirement;


    public bool isAchieveRequirements()
    {
        Profile playerProfile = GameManager.instance.playerManager.playerProfile;
        Collectible[] collectibles = GameManager.instance.rewardManager.collectibles;
        bool walk = isAchieve(planetRequirement.walk, playerProfile.walkingSpeed);
        bool sprint = isAchieve(planetRequirement.sprint, playerProfile.sprintingSpeed);
        bool jump = isAchieve(planetRequirement.jump, playerProfile.jumpHeight);
        bool sprintStamina = isAchieve(planetRequirement.sprintStamina, playerProfile.decreaseCostOvertime);
        bool jumpStamina = isAchieve(planetRequirement.jumpStamina, playerProfile.jumpCost);
        bool spaceshipBoost = isAchieve(planetRequirement.spaceshipBoost, playerProfile.thrustBoosted);
        bool spaceshipSpeed = isAchieve(planetRequirement.spaceshipSpeed, playerProfile.sprintingSpeed);
        bool spaceshipBulletOverheating = isAchieve(planetRequirement.spaceshipBulletOverheating, playerProfile.firingStaminaCost);
        bool isUnlockCollectible = true;
        for (int i = 0; i < planetRequirement.collectibles.Length; i++)
        {
            if (!planetRequirement.collectibles[i].isUnlockCollectible)
            {
                isUnlockCollectible = false;
                break;
            }
        }
        return isUnlockCollectible && walk && sprint && jump && sprintStamina && jumpStamina && spaceshipBoost && spaceshipSpeed && spaceshipBulletOverheating;
    }

    private bool isAchieve(int requirement, float currentStats)
    {
        return requirement == 0 ? true : requirement <= currentStats;
    }
    public string GetPlanetRequirements()
    {
        string requirements = "";

        Profile playerProfile = GameManager.instance.playerManager.playerProfile;
        Collectible[] collectibles = GameManager.instance.rewardManager.collectibles;
        requirements += GetRequirementData(planetRequirement.walk, playerProfile.walkingSpeed, "Walk", "Player");
        requirements += GetRequirementData(planetRequirement.sprint, playerProfile.sprintingSpeed, "Sprint", "Player");
        requirements += GetRequirementData(planetRequirement.jump, playerProfile.jumpHeight, "Jump", "Player");
        requirements += GetRequirementData(planetRequirement.sprintStamina, playerProfile.decreaseCostOvertime, "Sprint Stamina", "Player");
        requirements += GetRequirementData(planetRequirement.jumpStamina, playerProfile.jumpCost, "Jump Stamina", "Player");
        requirements += GetRequirementData(planetRequirement.spaceshipBoost, playerProfile.thrustBoosted, "Spaceship Boost", "Spaceship");
        requirements += GetRequirementData(planetRequirement.spaceshipSpeed, playerProfile.sprintingSpeed, "Spaceship Speed", "Spaceship");
        requirements += GetRequirementData(planetRequirement.spaceshipBulletOverheating, playerProfile.firingStaminaCost, "Spaceship Bullet Overheating", "Spaceship");
        for (int i = 0; i < planetRequirement.collectibles.Length; i++)
        {
            requirements += "> " + planetRequirement.collectibles[i].name + " Information Card\n";
        }
        return requirements;
    }

    private string GetRequirementData(int requirement, float currentStats, string name, string type)
    {
        string statsRequired = type + " Requirement: " + name + " " + requirement;
        return requirement == 0 ? "" : "> " + statsRequired + "\n";
    }

}
