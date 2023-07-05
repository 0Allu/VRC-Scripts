using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class Timer : UdonSharpBehaviour
{
    public TextMeshProUGUI tex;
    public float gameTimer=0f;
    
    void Update()
    {
        gameTimer += Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24; 

        string TimerString = string.Format("{0:0}:{1:00}:{2:00}",hours,minutes,seconds);

        tex.text = TimerString;
    }
}
