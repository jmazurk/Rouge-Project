using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ACharacter
{  
    public override void updateHealth(){

    }
    public override void processDeath()
    {
        Debug.Log("Game over!");
        Destroy(gameObject);
    }

    public void Update(){
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }
}
