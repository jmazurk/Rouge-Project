using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIScript : MonoBehaviour
{
    private Data dataManager;
    private CreatureStats playerStats;
    private int health;
    private int maxHealth;
    private int oldHealth;
    private int oldMaxHealth;
    public GameObject[] hearts;
    public Sprite heart_3;
    public Sprite heart_2;
    public Sprite heart_1;
    public Sprite heart_0;

    public void Start(){
        dataManager = GameObject.FindGameObjectWithTag("data_manager").GetComponent<Data>();
        playerStats = dataManager.playerStats;
    }

    void Update(){
        health = (int) playerStats.currentHealth;
        maxHealth = (int) playerStats.maxHealth;

        //health = Mathf.Min(health, maxHealth);

        bool changed = false;
        if(health != oldHealth || maxHealth != oldMaxHealth) changed = true;

        if(changed) {

        int numOfFullHearts = health / 3;
        int lastHeartState = health % 3;
        int numOfNotEmptyHearts = numOfFullHearts;

        if (lastHeartState != 0) numOfNotEmptyHearts++;

        for (int i = 0; i < numOfFullHearts; i++)
        {
            hearts[i].GetComponent<SpriteRenderer>().sprite = heart_3;
            hearts[i].SetActive(true);
        }

        int lastHeartId = numOfFullHearts;
        int firstEmptyHeartId = numOfFullHearts;

        if (lastHeartState != 0)
        {   
            hearts[lastHeartId].SetActive(true);
            firstEmptyHeartId++;
            switch (lastHeartState)
            {
                case 2:
                    hearts[lastHeartId].GetComponent<SpriteRenderer>().sprite = heart_2;
                    break;
                case 1:
                    hearts[lastHeartId].GetComponent<SpriteRenderer>().sprite = heart_1;
                    break;
            }
        }

        for(int i = firstEmptyHeartId; i < maxHealth/3;i++){
            hearts[i].GetComponent<SpriteRenderer>().sprite = heart_0;
            hearts[i].SetActive(true);
        }

        for(int i = maxHealth/3; i < hearts.Length;i++){
            hearts[i].SetActive(false);
        }

        }
    }
}
