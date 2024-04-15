using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject vuKhi;
    public GameObject VuKhi {get => vuKhi; private set => vuKhi = value;}

    [SerializeField]
    float maxhealth;
    public float Maxhealth {get => maxhealth; private set => maxhealth = value;}

    [SerializeField] // hồi phục
    float recovery;
    public float Recovery {get => recovery; private set => recovery = value;}

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed {get => moveSpeed; private set => moveSpeed = value;}

    [SerializeField]
    float might;
    public float Might {get => might; private set => might = value;}

    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed {get => projectileSpeed; private set => projectileSpeed = value;}

    [SerializeField]
    float magnet;
    public float Magnet {get => magnet; private set => magnet = value;}
}
