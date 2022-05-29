using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InkSplatter : MonoBehaviour
{
    public void Disappear()
    {
        Destroy(gameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
}
