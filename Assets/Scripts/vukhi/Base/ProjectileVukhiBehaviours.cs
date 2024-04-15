using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVukhiBehaviours : MonoBehaviour
{

    public VukhiScriptableObject vukhiData;
    protected Vector3 direction;
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

    public void DirectionChecker(Vector3 dir){
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry == 0){ //Left
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }else if(dirx == 0 && diry < 0){ // down
            scale.y = scale.y * -1;

        }else if(dirx == 0 && diry > 0){ // up
            scale.x = scale.x * -1;
        }else if(dir.x > 0 && dir.y > 0){ // R Up
            rotation.z  = 0f;
        } else if(dir.x > 0 && dir.y < 0 ){ // R Down
            rotation.z  = -90f;
        }
        else if(dir.x < 0 && dir.y > 0 ){ // L Up
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z  = -90f;
        }
        else if(dir.x < 0 && dir.y < 0 ){ // L Down
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z  = 0f;
        }
        
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
    protected virtual void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Monster")){
            MonsterStats m = col.GetComponent<MonsterStats>();
            m.TakeDamage(currentDamage);
            ReducePierce();
        }else if(col.CompareTag("Prop")){
            if(col.gameObject.TryGetComponent(out BreakableProps breakable)){
                breakable.TakeDamage(currentDamage);
                ReducePierce();
            }
        }
    }
    // xóa vũ khí khi chạm quái vật
    void ReducePierce(){
        currentPierce--;
        if(currentPierce <= 0){
            Destroy(gameObject);
        }
    }
}
