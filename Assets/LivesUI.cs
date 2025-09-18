using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public TMP_Text livesText;

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + "LIVES";
    }
}
