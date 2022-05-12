using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tlacitko : MonoBehaviour
{
    private Transform rot;
    [SerializeField] private GameObject go;
    [SerializeField] Vector2 dir;
    [SerializeField] float dur;
    float check = -1;
    Rigidbody2D body;
    Animator anim;
    bool buttonGuard = false;
    //float timeOnCollision;
    //bool notColliding;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rot = GetComponent<Transform>();
        rot = GetComponent<Transform>();
        body = go.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( check < 0)
        {
            //timeOnCollision = Time.deltaTime;
            anim.SetBool("isPressed", true);
            StartCoroutine(MovePlatform());
            check = -check;
            //notColliding = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (check > 0)
        {
            anim.SetBool("isPressed", false);
            StartCoroutine(MovePlatform());
            check = -check;
            //notColliding = true;
        }
    }
    IEnumerator MovePlatform()
    { 
        body.velocity = dir.normalized * check * -1;
        yield return new WaitForSeconds(dur);
        body.velocity = new Vector2(0, 0);
        yield break;
    }
}
