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
    private float pointMultiplier = 1;
    private float extraPoints = 0;
    public int comboStart = 2;
    public int almostPoints = 500;
    public int perfectPoints = 1000;
    public int missPointLoss = 500;
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
        if (hitAcc == "Miss")
        {
            ResetCombo();
            if (score - missPointLoss < 0)
            {
                score = 0;
            }
            else
            {
                score -= missPointLoss;
            }
        }
        else if (hitAcc == "Almost")
        {
            ResetCombo();
            score += almostPoints;
        }
        else if (hitAcc == "Perfect")
        {
            combo += 1;

            if (combo >= comboStart)
            {
                pointMultiplier += 0.1f;
                extraPoints = pointMultiplier * 10;
            }

            score += perfectPoints + (int)extraPoints;
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
