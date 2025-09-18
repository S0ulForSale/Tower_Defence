using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject completeUI;
    private void Start()
    {
            GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver) 
            return;
        if(PlayerStats.Lives <=0 )
        {
            EndGame();
        }
    }
    void EndGame ()
    {
        GameIsOver = true;
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        Debug.Log("LevelIsCompleted!");
        completeUI.SetActive(true);
    }
}
