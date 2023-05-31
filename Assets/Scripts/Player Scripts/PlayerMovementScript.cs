using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    CreatureStats myStats;
    private Vector2 movementInput;
    private Rigidbody2D myRigidBody;
    private float playerSpeed;
    private float playerAcceleration;
    private float playerDecceleration;
    private float velocityPower;

    public Animator animator;

    void Awake()
    {
        velocityPower = 0.9f;

        myRigidBody = GetComponent<Rigidbody2D>();
        myStats = GetComponent<CreatureStats>();
    }

    
    void Update(){
        #region UpdateStats
        playerSpeed = myStats.speed;
        playerAcceleration = myStats.acceleration;
        playerDecceleration = myStats.frictionPower;
        #endregion
    }

    void FixedUpdate()
    {
        #region InputForces
        //desired velocity
        Vector2 targetSpeed = movementInput * playerSpeed;
        //difference betweeen desired and current
        Vector2 speedDif = targetSpeed - myRigidBody.velocity;
        //modifier dependent on acceleration/ decceleration
        float accelerationRate = (Mathf.Abs(targetSpeed.magnitude) > 0.01f) ? playerAcceleration : playerDecceleration;
        //calcs final movement, exponential force growth according to a custom stat
        Vector2 movementForce = speedDif * accelerationRate;
        float multiplier = Mathf.Pow(movementForce.magnitude, velocityPower) / movementForce.magnitude;
        //if no force needed
        if(movementForce.magnitude == 0) multiplier = 0;
        movementForce *= multiplier;
        //apply force
        myRigidBody.AddForce(movementForce);
        #endregion

        #region animateMovement
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Speed", myRigidBody.velocity.magnitude);
        animator.SetBool("HasInput", movementInput.magnitude > 0);
        #endregion
    }

    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
}
