using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : VukhiController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedgarlic = Instantiate(vukhiData.Prefab);
        spawnedgarlic.transform.position = transform.position;
        spawnedgarlic.transform.parent = transform;
    }
}
