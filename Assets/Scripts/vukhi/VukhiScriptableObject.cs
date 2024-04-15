using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VukhiScriptableObject", menuName = "ScriptableObject/vukhi")]
public class VukhiScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab {get => prefab; private set => prefab = value;}
    
    [SerializeField]
    float damage;
    public float Damage {get => damage; private set => damage = value;}
    
    [SerializeField]
    public float speed;
    public float Speed {get => speed; private set => speed = value;}
    
    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration {get => cooldownDuration; private set => cooldownDuration = value;}
    
    [SerializeField]
    int pierce;
    public int Pierce {get => pierce; private set => pierce = value;}
    
}
