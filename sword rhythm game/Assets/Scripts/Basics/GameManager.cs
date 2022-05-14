using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }

    public string monsterLocation;
    public bool monsterHit = false;
    public int score = 0;
    public float scoreMultiplier = 1;

    public bool activeMonster = false;

    private void Update()
    {
        ManageMonsterSpawn();
        ManageHits();
        ManageScore();
    }

    private void ManageMonsterSpawn()
    {
        if (activeMonster)
        {
            
        }
    }

    private void ManageHits()
    {

    }

    private void ManageScore()
    {

    }

}
