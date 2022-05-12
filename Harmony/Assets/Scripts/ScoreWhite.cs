using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWhite : MonoBehaviour
{
    public TMPro.TextMeshProUGUI WhiteScoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        WhiteScoreText.text = ScoreNum + " x";
    }

    private void OnTriggerEnter2D(Collider2D ZetonBila)
    {
        if (ZetonBila.tag == "ZetonBila")
        {
            ScoreNum++;
            Destroy(ZetonBila.gameObject);
            WhiteScoreText.text = ScoreNum + " x";
        }
    }
}
