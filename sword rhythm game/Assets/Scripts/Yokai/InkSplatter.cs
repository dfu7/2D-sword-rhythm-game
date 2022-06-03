using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InkSplatter : MonoBehaviour
{
    public GameObject Panel;

    public void Disappear()
    {
        Destroy(gameObject);
    }

    public void ShowCredits()
    {
        Panel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

}
