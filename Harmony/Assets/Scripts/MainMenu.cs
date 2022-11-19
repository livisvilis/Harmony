using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Image title;
    Image decor;
    Image decor2;
    Image play;
    Image quit;
    public void Start()
    {
        //finding concrete game object 
        title = GameObject.Find("nadpis").GetComponent<Image>();
        decor = GameObject.Find("ozdoba").GetComponent<Image>();
        decor2 = GameObject.Find("ozdoba2").GetComponent<Image>();
        play = GameObject.Find("Play").GetComponent<Image>();
        quit = GameObject.Find("quit").GetComponent<Image>();
        //set opacity to 0%
        title.color = new Color(title.color.r, title.color.g, title.color.b, 0f); 
        decor.color = new Color(decor.color.r, decor.color.g, decor.color.b, 0f);
        decor2.color = new Color(decor2.color.r, decor2.color.g, decor2.color.b, 0f);
        play.color = new Color(play.color.r, play.color.g, play.color.b, 0f);
        quit.color = new Color(quit.color.r, quit.color.g, quit.color.b, 0f);
        //start corutines
        StartCoroutine("UIAnimationTitle");
        StartCoroutine("UIAnimationDecor");
        StartCoroutine("UIAnimationPlay");
        StartCoroutine("UIAnimationQuit");

    }
    public IEnumerator UIAnimationTitle()
    {
        while (title.color.a != 1f) // 0f - transparent 1f - fully opaque
        {
            float tempAlpha = title.color.a; 
            title.color = new Color(title.color.r, title.color.g, title.color.b, tempAlpha += 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
    public IEnumerator UIAnimationDecor()
    {
        yield return new WaitForSeconds(1f);
        while (decor.color.a != 1f)
        {
            float tempAlpha = decor.color.a;
            decor.color = new Color(decor.color.r, decor.color.g, decor.color.b, tempAlpha += 0.1f);
            yield return new WaitForSeconds(0.1f);
            decor2.color = new Color(decor2.color.r, decor2.color.g, decor2.color.b, tempAlpha);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
    public IEnumerator UIAnimationPlay()
    {
        yield return new WaitForSeconds(2f);
        while (play.color.a != 1f)
        {
            float tempAlpha = play.color.a;
            play.color = new Color(play.color.r, play.color.g, play.color.b, tempAlpha += 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
    public IEnumerator UIAnimationQuit()
    {
        yield return new WaitForSeconds(3f);
        while (quit.color.a != 1f)
        {
            float tempAlpha = quit.color.a;
            quit.color = new Color(quit.color.r, quit.color.g, quit.color.b, tempAlpha += 0.1f);
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
