using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviours : MonoBehaviour
{
    public VukhiScriptableObject vukhiData;
    public float destroyAfterSeconds;

    // 
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake(){
        currentDamage = vukhiData.Damage;
        currentSpeed = vukhiData.Speed;
        currentCooldownDuration = vukhiData.CooldownDuration;
        currentPierce = vukhiData.Pierce;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Monster")){
            MonsterStats m = col.GetComponent<MonsterStats>();
            m.TakeDamage(currentDamage);
            
        }else if(col.CompareTag("Prop")){
            if(col.gameObject.TryGetComponent(out BreakableProps breakable)){
                breakable.TakeDamage(currentDamage);
                
            }
        }
    }

}
