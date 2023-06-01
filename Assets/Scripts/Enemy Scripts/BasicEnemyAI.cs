using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    private CreatureStats myStats;
    private CreatureStats playerStats;
    private Data dataManager;
    void Awake()
    {
        myStats = GetComponent<CreatureStats>();
        dataManager = GameObject.FindGameObjectWithTag("data_manager").GetComponent<Data>();
        playerStats = dataManager.playerStats;
        //test pull request2
    }

    
    void Update()
    {
        dataManager = GameObject.FindGameObjectWithTag("data_manager").GetComponent<Data>();
        playerStats = dataManager.playerStats;

        myStats.myRigidbody.gameObject.transform.position=  Vector3.Lerp(
            gameObject.transform.position,
             playerStats.myRigidbody.gameObject.transform.position, 
             0.01f);
    }
}
