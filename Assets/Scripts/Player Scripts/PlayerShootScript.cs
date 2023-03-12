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
            shootBullet(shootingDirection);
        }
    }

    void shootBullet(Vector2 direction){
        #region add half player velocity to bullet velocity on the second axis
        Vector2 halfOtherAxisHeroVelocity = myRigidbody.velocity;
        Vector2 directionInversed = new Vector2 (0 ,0);
        if(direction.x == 0) directionInversed.x = 1;
        else directionInversed.y = 1;

        halfOtherAxisHeroVelocity *= directionInversed; //leaves only the part in the direction the player is not shooting
        halfOtherAxisHeroVelocity /= 2;

        Vector2 bulletVelocity = direction * myStats.bulletSpeed + halfOtherAxisHeroVelocity;
        #endregion

        spawnBullet(bulletVelocity.normalized, bulletVelocity.magnitude);
    }

    void spawnBullet(Vector2 direction, float speed){
        GameObject newBullet;
        Bullet newBulletStats;

        Vector2 bulletStartingPosition = myRigidbody.position + direction * myStats.bulletOffset;

        newBullet = Instantiate(straightBullet, bulletStartingPosition, transform.rotation);
        newBulletStats = newBullet.GetComponent<Bullet>();

        newBullet.layer = Layers.PLAYER_BULLET_LAYER;

        //newBulletStats.speed = myStats.bulletSpeed;
        newBulletStats.speed = speed;
        newBulletStats.movementDirection = direction;
        newBulletStats.hasLifeSpan = true;
        newBulletStats.lifeSpan = myStats.bulletLifespan;
        newBulletStats.damage = myStats.bulletDamage;

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
