using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEndBlack : MonoBehaviour
{
    public bool touchingBlack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("jin") == true)
        {
            touchingBlack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("jin") == true)
        {
            touchingBlack = false;
        }
    }
}
