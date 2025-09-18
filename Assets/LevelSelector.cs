using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void firstLevelButtonClick()
    {
        SceneManager.LoadScene(3);
    }
    public void secondLevelButtonClick() 
    {
        SceneManager.LoadScene(4);
    }
}
