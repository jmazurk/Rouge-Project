using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
    private EnemyStats myStats;

    public void Awake(){
        myStats = GetComponent<EnemyStats>();
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
