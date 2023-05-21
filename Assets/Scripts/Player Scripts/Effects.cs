using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    CreatureStats myStats;
    private bool isInvincible = false;
    private float invincibilityTimer;
    void Start()
    {
        myStats = GetComponent<CreatureStats>();
    }

    void controlInvincibility(){
        if(!isInvincible) return;

        invincibilityTimer -= Time.deltaTime;
        if(invincibilityTimer < 0){
            isInvincible = false;
            myStats.armourPercentage -= 1; 
        }
    }

    public void addInvincibility(float time){
        if(isInvincible) return;
        invincibilityTimer += time;
        myStats.armourPercentage += 1;
        isInvincible = true; 
    }
    void Update()
    {
        controlInvincibility();

    }
}
