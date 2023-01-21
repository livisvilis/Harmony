using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class DoorEnd : MonoBehaviour
{
    private DoorEndWhite dW;
    private DoorEndBlack dB;
    private Timer t;
    private Canvas endLevel;
    private GameObject jin;
    private GameObject jang;
    public TMPro.TextMeshProUGUI timerText;
    string minutes;
    string seconds;
    private GameObject logo;

    // Start is called before the first frame update
    void Start()
    {
        dW = GetComponentInChildren<DoorEndWhite>();
        dB = GetComponentInChildren<DoorEndBlack>();
        t = GetComponent<Timer>();
        endLevel = GameObject.Find("CanvasEndLevel").GetComponent<Canvas>();
        jin = GameObject.FindGameObjectWithTag("jin");
        jang = GameObject.FindGameObjectWithTag("jang");
        logo = GameObject.Find("logo");
        logo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //dW.touchingWhite
        if (dW.touchingWhite == true && dB.touchingBlack == true)
        {
            jin.gameObject.SetActive(false);
            jang.gameObject.SetActive(false);
            dB.gameObject.SetActive(false);
            dW.gameObject.SetActive(false);

            StartCoroutine("EndLevel");

            
            t.stopwatchActive = false;
            

            
        }
    }
    public IEnumerator EndLevel()
    {
        logo.SetActive(true);
        FindObjectOfType<AudioManager>().Play("end");
        yield return new WaitForSeconds(2.5f);
        endLevel.enabled = true;
        TimeSpan time = TimeSpan.FromSeconds(t.currentTime);
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
        timerText.text = minutes + ":" + seconds;
        yield break;
    }
}
