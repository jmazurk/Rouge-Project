using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacter : AEntity
{
    public float frictionPower {get;set;}
    public float acceleration {get;set;}
    public float maxHealth;
    public float currentHealth;
    public float fireRate;
    private float currentFireRateCooldown;
    public float bulletSpeed;
    public float bulletLifespan;
    public float bulletOffset {get;set;}
    public float bulletDamage;
    public float armourLinear = 0;
    public float armourPercentage = 0;

    public float bodyDamage;
    public void updateCurrentFireRateCooldown(){
        currentFireRateCooldown -= Time.deltaTime;
    }

    public bool canShoot(){
        return (currentFireRateCooldown < 0);
    }

    public void proccessShot(){
        currentFireRateCooldown = fireRate;
    }

    public abstract void processDeath();
    public abstract void updateHealth();
    public void getDamaged(float damage){
        damage -= armourLinear;
        damage = (1 - armourPercentage) * damage;
        currentHealth -= damage;
        if(currentHealth <= 0) processDeath();
        updateHealth();
    }

    public void addHealth(float health){
        currentHealth += health;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        updateHealth();
    }
}
