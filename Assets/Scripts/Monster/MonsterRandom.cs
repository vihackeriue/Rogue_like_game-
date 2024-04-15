using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandom : MonoBehaviour
{
    // định nghĩa từng đợt quái 
    [System.Serializable]
    public class Wave {
        public string waveName;
        public List<MonsterGroup> monsterGroup;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }

    [System.Serializable]
    public class MonsterGroup{
        public string monsterName;
        public int monsterCount;
        public int spawnCount;
        public GameObject monsterPrefab;
    
    }

    public List<Wave> waves;
    public int currentWaveCount;

    [Header("Spawner Attributes")]
    float spawnTimer;
    public int monstersAlive;
    public int maxMonsterAllowed;
    public bool maxMonsterReached = false;
    public float waveInterval;

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints;



    Transform player;

    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
       
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= waves[currentWaveCount].spawnInterval){
            spawnTimer = 0f;
            SpawnMonsters();
        }
    }

    IEnumerator BeginNextWave(){
        yield return new WaitForSeconds(waveInterval);
        if(currentWaveCount < waves.Count - 1){
            currentWaveCount ++;
            CalculateWaveQuota();
        }

    }
    void CalculateWaveQuota(){
        int currentWaveQuota = 0;
        foreach (var item in waves[currentWaveCount].monsterGroup)
        {
            currentWaveQuota += item.monsterCount;
        } 
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }
    void SpawnMonsters(){
        if(waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota){
            foreach (var item in waves[currentWaveCount].monsterGroup)
            {
                
                if(item.spawnCount < item.monsterCount ){
                    // giới hạn quái sinh ra
                    if( monstersAlive >= maxMonsterAllowed){
                        maxMonsterReached = true;
                        return;
                    }

                    Instantiate(item.monsterPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
                    // Vector2 randomPosition = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));
                    // Instantiate(item.monsterPrefab, randomPosition, Quaternion.identity);
                    item.spawnCount ++;
                    waves[currentWaveCount].spawnCount++;
                    monstersAlive++;
                }
            }

        }
        if(monstersAlive < maxMonsterAllowed){
            maxMonsterReached = false;
        }

    }
    public void OnMonsterKill(){
        monstersAlive--;
    }
}
