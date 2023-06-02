using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    private CreatureStats myStats;

    public void Awake(){
        myStats = GetComponent<CreatureStats>();
    }
    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.layer == Layers.ENEMY_LAYER){
            
            myStats.getDamaged(collision.gameObject
            .GetComponentInChildren<CreatureStats>()
            .bodyDamage);

            //gameObject.GetComponent<Rigidbody2D>().velocity *= -2;

            myStats.myEffects.addInvincibility(3);
        }
        else if(collision.gameObject.layer == Layers.ENEMY_BULLET_LAYER){
            
            myStats.getDamaged(collision.gameObject
            .GetComponentInChildren<Bullet>()
            .damage);

            Destroy(collision.gameObject);
            myStats.myEffects.addInvincibility(3);
        }
    }
}

