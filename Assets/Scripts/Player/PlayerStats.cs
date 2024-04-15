using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    // [HideInInspector]
    public float currenthealth;
    [HideInInspector]
    public float currentRecovery;
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentMight;
    [HideInInspector]
    public float currentProjectileSpeed;
    [HideInInspector]
    public float currentMagnet;

    public List<GameObject> spawnedVukhi;

    // kinh nghiệm và level
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap = 100;
    // public int experienceCapIncrease;


    [System.Serializable]
    public class LevelRange {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }
    [Header("I-Frames")]
    public float invincibilityDurration;
    float invincibilityTimer;
    bool isInvincible;


    // thanh máu
    HealthBarPlayer healthbar;


    public List<LevelRange> levelRanges;

    void Awake()
    {
        // characterData = CharacterSeclector.GetData();
        // CharacterSeclector.instance.DestroySingleton();

        currenthealth = characterData.Maxhealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentMagnet = characterData.Magnet;
        // healthbar.SetMaxHealth(characterData.Maxhealth);
        // SqawnVukhi(characterData.StartingVukhi);
    }
    void Start(){
        experienceCap = levelRanges[0].experienceCapIncrease;

        healthbar = GetComponent<HealthBarPlayer>();
    if (healthbar != null) {
        healthbar.SetMaxHealth(currenthealth);
    } else {
        Debug.LogError("HealthBarPlayer reference not found!");
    }
        
    }
    void Update(){
        if(invincibilityTimer > 0){
            invincibilityTimer -= Time.deltaTime;
        }else if(isInvincible){
            isInvincible = false;
        }
        Recovery();
    }

    // Start is called before the first frame update
   

    public void IncreaseExperience(int amount){

        experience += amount;
        levelUpChecker();
    }
    // kiểm tra kinh nghiệm đủ để lên level
    void levelUpChecker(){
        if(experience >= experienceCap){ // experienceCap là giới hạn kinh nghiệm
            level++;
            experience -= experienceCap;
            int experienceCapIncrease = 0;
            foreach (LevelRange item in levelRanges)
            {
                if(level >= item.startLevel && level <= item.endLevel){
                    experienceCapIncrease = item.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }
    public void TakeDamage(float dmg){

        if(!isInvincible){
            currenthealth -= dmg;
            // healthbar.SetHealth(currenthealth);
            invincibilityTimer = invincibilityDurration;
            isInvincible = true;
            if(currenthealth <= 0){
                Kill();
            }
        }
        

    }
    public void Kill(){
        Destroy(gameObject);
    }
    //  Hồi lại máu
    public void RestoreHealth(float amount){
        if(currenthealth < characterData.Maxhealth){
            currenthealth += amount;
            // healthbar.SetHealth(currenthealth);
            if(currenthealth > characterData.Maxhealth){
                currenthealth = characterData.Maxhealth;
            }
        }
    }
    void Recovery(){
        if(currenthealth < characterData.Maxhealth){
            currenthealth += currentRecovery * Time.deltaTime;

            if(currenthealth > characterData.Maxhealth){
                currenthealth = characterData.Maxhealth;
            }
        }
    }

    public void SqawnVukhi(GameObject w){
        GameObject sp = Instantiate(w, transform.position, Quaternion.identity);
        sp.transform.SetParent(transform);
        spawnedVukhi.Add(sp);
    }
    
   
}
