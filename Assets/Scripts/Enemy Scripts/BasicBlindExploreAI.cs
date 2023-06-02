using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlindExploreAI : MonoBehaviour
{
    bool hasDestination = false;
    public float maxVertical = 0.9f;
    public float maxHorizontal = 1.7f;
    public Vector3 currentDestination;
    private CreatureStats myStats;
    private CreatureStats playerStats;
    private Data dataManager;

    static float NextFloat(float min, float max){
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
    void Start()
    {
        hasDestination = false;
        myStats = GetComponent<CreatureStats>();
        dataManager = GameObject.FindGameObjectWithTag("data_manager").GetComponent<Data>();
        playerStats = dataManager.playerStats;
    }
    void Update()
    {
       
        if(Vector3.Distance(currentDestination, gameObject.transform.position) < 0.1f) hasDestination = false;

        if(hasDestination == false){
            
            currentDestination.x = NextFloat(-maxHorizontal, maxHorizontal);
            currentDestination.y = NextFloat(-maxVertical, maxVertical);
            currentDestination.z = 0;
            hasDestination = true;
        }

        dataManager = GameObject.FindGameObjectWithTag("data_manager").GetComponent<Data>();
        playerStats = dataManager.playerStats;


        myStats.myRigidbody.gameObject.transform.position=  Vector3.MoveTowards(
            gameObject.transform.position,
             currentDestination, 
             0.01f);


    }
}
