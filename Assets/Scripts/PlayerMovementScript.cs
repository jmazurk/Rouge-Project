using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    public Vector2 movementInput;
    private Rigidbody2D myRigidBody;
    public float playerSpeed;
    public float playerAcceleration;
    public float playerDecceleration;
    public float velocityPower;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
    }

    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
}
