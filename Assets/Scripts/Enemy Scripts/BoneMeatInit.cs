using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneMeatInit : MonoBehaviour
{
    CreatureStats myStats;

    void Awake(){
        myStats = gameObject.GetComponent<CreatureStats>();

        myStats.maxHealth = 7;
        myStats.currentHealth = 7;
        myStats.bodyDamage = 1;
    }
}
