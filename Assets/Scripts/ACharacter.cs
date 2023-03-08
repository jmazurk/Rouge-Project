using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacter : AEntity
{
    public float frictionPower {get;set;}
    public float acceleration {get;set;}
    public float maxHealth {get;set;}
    public float currentHealth {get;set;}
    public float fireRate;
    private float currentFireRateCooldown;
    public float bulletSpeed;
    public float bulletLifespan;
    public float bulletOffset;
    public void updateCurrentFireRateCooldown(){
        currentFireRateCooldown -= Time.deltaTime;
    }

    public bool canShoot(){
        return (currentFireRateCooldown < 0);
    }

    public void proccessShot(){
        currentFireRateCooldown = fireRate;
    }
}
