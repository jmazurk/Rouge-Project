using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStats : ACharacter
{  
    public override void updateHealth(){

    }
    public override void processDeath()
    {
        Destroy(gameObject);
    }

    public void Awake(){
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myEffects = GetComponent<Effects>();
    }

    public void Update(){
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }
}
