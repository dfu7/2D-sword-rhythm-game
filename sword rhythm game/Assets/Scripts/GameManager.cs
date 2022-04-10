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

    public string monsterState;
    public bool hit = false;
    public int score = 0;
    public float scoreMultiplier = 1;

    private void Update()
    {
        Manage
        ManageScore();
    }

    private void ManageScore()
    {
        score 
    }

}
