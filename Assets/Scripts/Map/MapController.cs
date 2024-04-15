using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terr;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerr;
    public LayerMask terrainMask;
    PlayerMovement pm; 
    public GameObject currentMap;

    [Header("Optimization")]
    public List<GameObject> SpawnMaps;
    GameObject latestMap;
    public float maxOpDist;
    float opDist;

    float optimizerCooldown;
    public float optimizerCooldownDur;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker(){
        if(!currentMap){
            return;
        }

        if(pm.moveDir.x > 0 && pm.moveDir.y == 0){ //R
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("Right").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Right").position;
                SpawnChunk();
            }
        }else if(pm.moveDir.x < 0 && pm.moveDir.y == 0){ //L
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("Left").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y > 0){//Up
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("Up").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y < 0){//Down
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("Down").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y > 0){//R Up
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("Right Up").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y < 0){//R Down
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("Right Down").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }
        else if(pm.moveDir.x < 0 && pm.moveDir.y > 0){//L Up
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("left Up").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }
        else if(pm.moveDir.x < 0 && pm.moveDir.y < 0){//L Down
            if(!Physics2D.OverlapCircle(currentMap.transform.Find("left Down").position, checkerRadius, terrainMask)){
                noTerr = currentMap.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
    }
    
    void SpawnChunk(){
         int rand = Random.Range(0, terr.Count);
         latestMap =  Instantiate(terr[rand], noTerr, Quaternion.identity);
         SpawnMaps.Add(latestMap);
    
    }
    void ChunkOptimizer(){
        optimizerCooldown -= Time.deltaTime;
        if(optimizerCooldown <= 0f ){
            optimizerCooldown = optimizerCooldownDur;
        }else{
            return;
        }

        foreach(GameObject item in SpawnMaps){
            opDist = Vector3.Distance(player.transform.position, item.transform.position);
            if(opDist > maxOpDist){
                item.SetActive(false);
            }else{
                item.SetActive(true);
            }
        
        }
    }
}
