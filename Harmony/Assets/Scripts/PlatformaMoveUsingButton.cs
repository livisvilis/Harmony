using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaMoveUsingButton : MonoBehaviour
{
    [SerializeField] Transform endPos, startPos;
    bool checkG;
    bool shouldMove;
    bool isRunning;
    bool moving;
    AudioSource sound;
    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("platform");
        sound = gameObject.GetComponent<AudioSource>();
    }
    IEnumerator movePlatform(Vector3 target, float speed, bool check)
    {
        /*
        if(isRunning == true)
        {
            yield  break;
        }
        isRunning = true;*/
        Vector3 startPos = transform.position;
        
        float time = 0f;


        while (transform.position != target && check == checkG)
        {
            transform.position = Vector3.Lerp(startPos, target, (time / Vector3.Distance(startPos, target)) * speed);
            time += Time.deltaTime;
            yield return null;
            moving = true;
        }
        moving = false;
        //FindObjectOfType<AudioManager>().StopPlaying("platform");
        //isRunning = false;
    }

    void Update()
    {
        if (shouldMove)
        {
            checkG = true;
            StartCoroutine(movePlatform(endPos.position, 2f, true));
        }
        if (!shouldMove)
        {
            checkG = false;
            StartCoroutine(movePlatform(startPos.position, 2f, false));
        }

        if (moving == true)
        {
            sound.volume = 1f;
        }
        else
        {
            sound.volume = 0f;
        }
    }

    public void SetShouldMove(bool sm) 
    {
        shouldMove = sm;
        
    }
}
