using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalScoreSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI letterGrade;

    // Start is called before the first frame update
    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("TotalScore");
        scoreText.SetText(finalScore.ToString());

        if(finalScore >= 1000000)
        {
            letterGrade.SetText("RIZUDO");
        }
        if(finalScore >= 300000)
        {
            letterGrade.SetText("S+");
        }
        else if(finalScore >= 250000)
        {
            letterGrade.SetText("S");
        }
        else if (finalScore >= 200000)
        {
            letterGrade.SetText("A");
        }
        else if (finalScore >= 100000)
        {
            letterGrade.SetText("B");
        }
        else if (finalScore >= 50000)
        {
            letterGrade.SetText("C");
        }
        else if (finalScore >= 25000)
        {
            letterGrade.SetText("D");
        }
        else
        {
            letterGrade.SetText("Try Again!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        PlayerPrefs.DeleteKey("TotalScore");
    }

}
