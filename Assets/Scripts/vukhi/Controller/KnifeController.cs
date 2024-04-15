using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : VukhiController
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
       GameObject spawnedKnife = Instantiate(vukhiData.Prefab);
       spawnedKnife.transform.position = transform.position;

       spawnedKnife.GetComponent<KnifeBehavious>().DirectionChecker(pm.lastMoveVector);
    }
}
