using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    private PlayerStats myStats;

    public void Awake(){
        myStats = GetComponent<PlayerStats>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == Layers.ENEMY_LAYER){
            
            myStats.getDamaged(collision.gameObject
            .GetComponentInChildren<EnemyStats>()
            .bodyDamage);

            gameObject.GetComponent<Rigidbody2D>().velocity *= -2;
        }
        else if(collision.gameObject.layer == Layers.ENEMY_BULLET_LAYER){
            
            myStats.getDamaged(collision.gameObject
            .GetComponentInChildren<Bullet>()
            .damage);

            Destroy(collision.gameObject);
        }
    }
}

