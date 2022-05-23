using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tlacitko : MonoBehaviour
{
    
    public bool shouldMove;
    Animator anim;
    [SerializeField] GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        go.SendMessage("SetShouldMove", true);
        anim.SetBool("isPressed", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        go.SendMessage("SetShouldMove", false);
        anim.SetBool("isPressed", false);
    }

    /*
    private Transform rot;
    [SerializeField] private GameObject go;
    [SerializeField] Vector2 dir;
    [SerializeField] float dur;
    int check = 1;
    bool buttonIsPressed;
    Rigidbody2D body;
    Animator anim;
    bool buttonGuard = false;
    [SerializeField] int boundrycheck = 0;

    [SerializeField] private Transform startPoz;
    [SerializeField] private Transform endPoz;
    bool endDistance;
    bool startDistance;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rot = GetComponent<Transform>();
        rot = GetComponent<Transform>();
        body = go.GetComponent<Rigidbody2D>();
        startPoz = go.transform;
        dir = (endPoz.position - startPoz.position).normalized;
    }
    private void Update()
    {
        distanceCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!buttonIsPressed)
        {
            buttonIsPressed = true;
            anim.SetBool("isPressed", true);
            StopCoroutine(MovePlatformBack());
            StartCoroutine(MovePlatform());
            check = -check;
            Debug.Log(boundrycheck);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (buttonIsPressed)
        {
            buttonIsPressed = false;
            anim.SetBool("isPressed", false);
            StopCoroutine(MovePlatform());
            StartCoroutine(MovePlatformBack());
            check = -check;
            
            Debug.Log(boundrycheck);
        }
    }
    IEnumerator MovePlatform()
    {
        
        body.velocity = dir.normalized;
        yield return new WaitUntil(() => endDistance);
        body.velocity = new Vector2(0, 0);
        yield break;

    }

    IEnumerator MovePlatformBack()
    {

        body.velocity = dir.normalized * -1;
        yield return new WaitUntil(() => startDistance);
        body.velocity = new Vector2(0, 0);
        yield break;

    }

    private void distanceCheck()
    {
        endDistance = 1 > Vector2.Distance(endPoz.position, go.transform.position);
        startDistance = 1 > Vector2.Distance(startPoz.position, go.transform.position);
    }
    */

}
