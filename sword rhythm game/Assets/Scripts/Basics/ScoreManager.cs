using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int combo = 0;
    public int failCombo = 0;
    public int failThreshold = 10;
    private float pointMultiplier = 1;
    private float extraPoints = 0;
    public int comboStart = 2;
    public int almostPoints = 500;
    public int perfectPoints = 1000;
    public int missPointLoss = 500;
    public int failPointLoss = 1000;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    public AudioSource audioSource;

    private void OnEnable()
    {
        PlayerControls.hitAcc += ConvertScore;
    }

    private void OnDisable()
    {
        PlayerControls.hitAcc -= ConvertScore;
    }

    void ConvertScore(string hitAcc)
    {
        if (hitAcc == "Fail")
        {
            Debug.LogWarning("F");
            ResetCombo();
            score -= failPointLoss;
            failCombo += 1;
        }

        if (hitAcc == "Miss")
        {
            ResetCombo();
            score -= missPointLoss;
        }

        if (failCombo >= failThreshold)
        {
            SceneManager.LoadScene("Lose");
        }

        if (hitAcc == "Almost")
        {
            failCombo = 0;
            ResetCombo();
            score += almostPoints;
        }
        
        if (hitAcc == "Perfect")
        {
            failCombo = 0;
            combo += 1;

            if (combo >= comboStart)
            {
                pointMultiplier += 0.1f;
                extraPoints = pointMultiplier * 10;
            }

            score += perfectPoints + (int)extraPoints;
        }


        if (score < 0)
        {
            score = 0;
        }

        scoreText.SetText(score.ToString() + " pts");
        comboText.SetText(/*"Combo: " + */combo.ToString());
    }

    void ResetCombo()
    {
        combo = 0;
        pointMultiplier = 1;
        extraPoints = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {

            SceneManager.LoadScene("Fin");
        }
    }
}
