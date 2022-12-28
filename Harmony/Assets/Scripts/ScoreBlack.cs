using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBlack : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BlackScoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        BlackScoreText.text = ScoreNum + " x";
    }

    private void OnTriggerEnter2D(Collider2D ZetonCerna)
    {
        if (ZetonCerna.tag == "ZetonCerna")
        {
            ScoreNum++;
            FindObjectOfType<AudioManager>().Play("diamond");
            Destroy(ZetonCerna.gameObject);
            BlackScoreText.text = ScoreNum + " x";
        }
    }
}
