using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    PlayerStats myStats;
    void Awake()
    {
        myStats = GetComponent<PlayerStats>();
        myStats.speed = 1.3f;
        myStats.acceleration = 10f;
        myStats.frictionPower = 7f;
        myStats.id = 1;

        myStats.fireRate = 0.4f;
        myStats.bulletSpeed = 1.5f;
        myStats.bulletLifespan = 1;
        myStats.bulletOffset = 0.1f;
    }
}
