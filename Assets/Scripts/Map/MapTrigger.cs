using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    MapController mc;
    public GameObject targetMap;
    // Start is called before the first frame update
    void Start()
    {
        mc = FindObjectOfType<MapController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D col){
        if(col.CompareTag("Player")){
            mc.currentMap = targetMap;
        }

    }

    private void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            if(mc.currentMap == targetMap){
                 mc.currentMap = null;
            }
           
        }

    }
}
