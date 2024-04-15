using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviours : MeleeBehaviours
{

    List<GameObject> markedMonsters;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Monster") && !markedMonsters.Contains(col.gameObject)){
            MonsterStats m = col.GetComponent<MonsterStats>();
            m.TakeDamage(currentDamage);
            markedMonsters.Add(col.gameObject);
        }else if(col.CompareTag("Prop")){
            if(col.gameObject.TryGetComponent(out BreakableProps breakable)){
                breakable.TakeDamage(currentDamage);
                markedMonsters.Add(col.gameObject);
            }
        }
    }


}
