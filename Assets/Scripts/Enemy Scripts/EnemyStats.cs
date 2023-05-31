using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : ACharacter
{
    public override void processDeath()
    {
        Destroy(gameObject);
    }
    public override void updateHealth(){}

    
}
