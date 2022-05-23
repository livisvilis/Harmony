using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaMoveUsingButton : MonoBehaviour
{
    [SerializeField] Transform endPos, startPos;
    bool checkG;
    bool shouldMove;

    IEnumerator movePlatform(Vector3 target, float speed, bool check)
    {
        Vector3 startPos = transform.position;
        float time = 0f;

        while (transform.position != target && check == checkG)
        {
            transform.position = Vector3.Lerp(startPos, target, (time / Vector3.Distance(startPos, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
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

    }

    public void SetShouldMove(bool sm) 
    {
        shouldMove = sm;
        Debug.Log(sm);
    }
}
