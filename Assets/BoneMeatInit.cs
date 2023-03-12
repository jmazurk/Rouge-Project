using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneMeatInit : MonoBehaviour
{
    EnemyStats myStats;

    void Awake(){
        myStats = gameObject.GetComponent<EnemyStats>();

        myStats.maxHealth = 7;
        myStats.currentHealth = 7;
        myStats.bodyDamage = 1;
    }
}
