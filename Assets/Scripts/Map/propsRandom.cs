using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propsRandom : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps(){
        foreach(GameObject sp in propSpawnPoints){
            int rand = Random.Range(0, propPrefabs.Count);
            
            GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
            
        // Lấy reference đến Sprite Renderer của đối tượng được tạo ra
        SpriteRenderer propRenderer = prop.GetComponent<SpriteRenderer>();
            // Kiểm tra xem Sprite Renderer có tồn tại hay không
        if (propRenderer != null) {
            // Thiết lập Sorting Layer của Sprite Renderer thành "props"
            propRenderer.sortingLayerName = "props";
        } else {
            Debug.LogWarning("Sprite Renderer not found on prop prefab.");
        }

        // Gắn đối tượng prop vào sp.transform
            prop.transform.parent = sp.transform;
        }
    }
}
