using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : ProductionPickup, ICollectible
{
    public int ExperienceGranted;

    public void Collect(){
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExperience(ExperienceGranted);
        // Destroy(gameObject);
    }

    
}
