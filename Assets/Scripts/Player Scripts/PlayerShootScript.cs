using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootScript : MonoBehaviour
{
    public Vector2 shootingDirection;
    private Rigidbody2D myRigidbody;
    PlayerStats myStats;
    public GameObject straightBullet;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myStats = GetComponent<PlayerStats>();
    }

    void FixedUpdate(){
        myStats.updateCurrentFireRateCooldown();

        if(shootingDirection.magnitude > 0 && myStats.canShoot()){
            spawnBullet(shootingDirection);
        }
    }

    void spawnBullet(Vector2 direction){
        GameObject newBullet;
        StraightBulletScript newBulletStats;

        Vector2 bulletStartingPosition = myRigidbody.position + direction * myStats.bulletOffset;

        newBullet = Instantiate(straightBullet, bulletStartingPosition, transform.rotation);
        newBulletStats = newBullet.GetComponent<StraightBulletScript>();

        newBulletStats.speed = myStats.bulletSpeed;
        newBulletStats.movementDirection = direction;
        newBulletStats.hasLifeSpan = true;
        newBulletStats.lifeSpan = myStats.bulletLifespan;

        myStats.proccessShot();
    }
    Vector2 simplifyDirection(Vector2 direction){
        if(direction.magnitude == 0) return direction;

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            direction.y = 0;
            direction.x = Mathf.Sign(direction.x);
        }
        else{
            direction.x = 0;
            direction.y = Mathf.Sign(direction.y);
        }
        return direction;
    }
    void OnLook(InputValue lookValue){
        shootingDirection = lookValue.Get<Vector2>();
        shootingDirection = simplifyDirection(shootingDirection);
    }
}
