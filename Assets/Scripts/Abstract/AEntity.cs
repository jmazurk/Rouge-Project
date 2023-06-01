using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEntity : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed {get;set;}
    public int id;
}
