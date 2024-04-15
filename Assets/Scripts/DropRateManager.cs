using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops{
        public string name;
        public GameObject prefab;
        public float dropRate;
    }

    public List<Drops> drops;

    void OnDestroy(){
        float randomNumber = UnityEngine.Random.Range(0f, 100f);
        List<Drops> possibleDrops = new List<Drops>();


        foreach(Drops d in drops){
            if(randomNumber <= d.dropRate){
                possibleDrops.Add(d);
            }
        }
        if(possibleDrops.Count > 0){
            Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.prefab, transform.position, Quaternion.identity);
        }
        
    }
    
}
