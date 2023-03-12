using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AProjectile : AEntity
{
    public float size;
    public float lifeSpan;
    public bool hasLifeSpan;
    public Vector2 movementDirection;
    public float damage;

    public abstract void destroyProjectile();
    public abstract void Update();
    public void updateLifespan(){
        if(!hasLifeSpan) return;

        lifeSpan -= Time.deltaTime;
        if(lifeSpan < 0){
            destroyProjectile();
        } 
    }
}
