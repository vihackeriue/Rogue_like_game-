using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VukhiController : MonoBehaviour
{

    [Header("Weapon Stats")]

    public VukhiScriptableObject vukhiData;
    // public GameObject prefab;
    // public float damage;
    // public float speed;
    // public float cooldownDuration;
    float currentCooldown;
    // public int pierce;

    protected PlayerMovement pm;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = vukhiData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f){
            Attack();
        }
    }
    protected virtual void Attack(){
        currentCooldown = vukhiData.CooldownDuration;
    }
}
