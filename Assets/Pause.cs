using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject ui;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            //Time.timeScale = 0f;
        }
        else
        {
            //Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
         Toggle();
        SceneManager.LoadScene(3);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
}
