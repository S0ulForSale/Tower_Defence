using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class completeLevel : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene(2);
    }
    public void Retry()
    {
        SceneManager.LoadScene(3);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
}
