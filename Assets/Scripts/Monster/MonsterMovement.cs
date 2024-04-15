using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    // public MonsterScriptableObject monsterData;
    MonsterStats monster;
    Transform player;
    void Start()
    {
        monster = GetComponent<MonsterStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, monster.currentMoveSpeed * Time.deltaTime);
    }
}
