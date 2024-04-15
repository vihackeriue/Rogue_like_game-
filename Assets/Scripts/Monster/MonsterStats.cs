using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    public MonsterScriptableObject monsterData;

   [HideInInspector] 
   public float currentMoveSpeed;
   [HideInInspector]
   public float currenthealth;
   [HideInInspector]
   public float currentDamage;


   public float despawnDistane = 20f;
   Transform player;

   void Awake(){
        currentMoveSpeed = monsterData.MoveSpeed;
        currenthealth = monsterData.MaxHealth;
        currentDamage = monsterData.Damage;
   }
   void Start(){
    player = FindObjectOfType<PlayerStats>().transform;

   }
   void Update(){
    if(Vector2.Distance(transform.position, player.position) >= despawnDistane){
            ReturnMonster();
    }
   }
   public void TakeDamage(float dmg){

        currenthealth -= dmg;
        if( currenthealth <= 0){
            Kill();
        }
   }
   public void Kill(){
        Destroy(gameObject);
   }

   private void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
    private void OnDestroy(){
        MonsterRandom mr = FindObjectOfType<MonsterRandom>();
        mr.OnMonsterKill();
    }
    void ReturnMonster(){
        MonsterRandom mr = FindObjectOfType<MonsterRandom>();
        transform.position = player.position + mr.relativeSpawnPoints[Random.Range(0,mr.relativeSpawnPoints.Count)].position;
    }
}
