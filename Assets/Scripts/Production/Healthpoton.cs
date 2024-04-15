using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpoton : ProductionPickup, ICollectible
{
     public int restoreHealth;
     public int experience;
    public void Collect(){
        PlayerStats player = FindObjectOfType<PlayerStats>();
        // check nếu nhặt được kinh nghiệm thì tăng kinh nghiệm và ngược lại
        if(restoreHealth > 0){
            player.RestoreHealth(restoreHealth);
        }
        if(experience > 0){
            player.IncreaseExperience(experience);
        }
        // Destroy(gameObject);
    }

}
