using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public bool stopwatchActive = true;
    public float currentTime;
    public TMPro.TextMeshProUGUI currentTimeText;
    string minutes;
    string seconds;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        if (time.Minutes < 10)
        {
            minutes = "0" + time.Minutes.ToString();
        }
        else { minutes = time.Minutes.ToString(); }
        if (time.Seconds < 10)
        {
            seconds = "0" + time.Seconds.ToString();
        }
        else { seconds = time.Seconds.ToString(); }
        //currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        currentTimeText.text = minutes + ":" + seconds;

    }
}