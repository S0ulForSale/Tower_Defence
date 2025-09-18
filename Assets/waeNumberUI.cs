using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class waeNumberUI : MonoBehaviour
{
    public TMP_Text waveNum;

    void Update()
    {
        waveNum.text = PlayerStats.Rounds + " ROUND";
    }
}
