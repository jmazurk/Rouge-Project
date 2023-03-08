using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBulletScript : AProjectile
{
    private Rigidbody2D myRigidbody;

    public void Start(){
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    public override void Update()
    {
        myRigidbody.velocity = movementDirection.normalized * speed;
        updateLifespan();
    }
    public override void destroyProjectile(){
        Destroy(gameObject);
    }
}
