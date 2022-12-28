using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paka : MonoBehaviour
{
    private Transform rot;
    [SerializeField] GameObject go;
    private float previousRot;
    private bool previous;
    private bool actual;
    private bool colision;
    void Start()
    {
        rot = GetComponent<Transform>();
        previousRot = rot.rotation.z;
        if (previousRot > 0)
        {
            previous = false;
        }
        else
        {
            previous = true;
        }
    }
    void Update()
    {
        
        if (rot.rotation.z > 0 )
        {
            go.SendMessage("SetShouldMove", false);
            actual = false;

        }
        if (rot.rotation.z < 0)
        {
            go.SendMessage("SetShouldMove", true);
            actual = true;
        }

        if (actual != previous)
        {
            FindObjectOfType<AudioManager>().Play("button");
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        previousRot = rot.rotation.z;
        if (previousRot > 0)
        {
            previous = false;
        }
        else
        {
            previous = true;
        }
        
    }
    /*
    private Transform rot;
    [SerializeField] private GameObject go;
    [SerializeField] Vector2 dir;
    [SerializeField] float dur;
    float leverCheck;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        rot = GetComponent<Transform>();
        leverCheck = -1;
        body = go.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((rot.rotation.z > 0 && leverCheck > 0)|| ((rot.rotation.z < 0 && leverCheck < 0)))
        {
            StartCoroutine(MovePlatform());
            leverCheck = -leverCheck;
        }
        
    }

    IEnumerator MovePlatform()
    {
        body.velocity = dir.normalized * leverCheck * -1;
        yield return new WaitForSeconds(dur);
        body.velocity = new Vector2(0, 0);
        yield break;
    }
    */
}
