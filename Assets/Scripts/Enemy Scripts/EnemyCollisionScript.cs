using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
    private CreatureStats myStats;

    public void Awake(){
        myStats = GetComponent<CreatureStats>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == Layers.PLAYER_BULLET_LAYER){
            
            myStats.getDamaged(collision.gameObject
            .GetComponentInChildren<Bullet>()
            .damage);

            Destroy(collision.gameObject);
        }
    }
}
