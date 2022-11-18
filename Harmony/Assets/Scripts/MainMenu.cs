using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Image title;
    public void Start()
    {
        title = GameObject.Find("nadpis").GetComponent<Image>();
        title.color = new Color(title.color.r, title.color.g, title.color.b, 0f); //set opacity to 0%
        StartCoroutine("UIAnimation");

    }
    public IEnumerator UIAnimation()
    {
        while (title.color.a != 1f)
        {
            float tempAlpha = title.color.a;
            title.color = new Color(title.color.r, title.color.g, title.color.b, tempAlpha += 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RefreshGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
