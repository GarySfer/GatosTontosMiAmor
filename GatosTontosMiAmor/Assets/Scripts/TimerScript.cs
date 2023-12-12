using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    public bool isTimerActive = true;
    int minutes;
    int seconds;
    
    void Update()
    {
        if (isTimerActive)
        {
            elapsedTime += Time.deltaTime;
        }
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);        
}

    public int getTimeSeconds() {
        int finalseconds = (minutes * 60) + seconds;

        return finalseconds;
    }
    public void addTime(int time) {
        elapsedTime += time;
    }
}
