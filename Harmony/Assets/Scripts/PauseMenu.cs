using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Canvas pauseMenu;
    public bool isPaused;
    private GameObject jin;
    private GameObject jang;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("CanvasPause").GetComponent<Canvas>();
        jin = GameObject.FindGameObjectWithTag("jin");
        jang = GameObject.FindGameObjectWithTag("jang");
        sound = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        jin.gameObject.SetActive(false);
        jang.gameObject.SetActive(false);
        sound.volume = 0f;
        pauseMenu.enabled = true;
        isPaused = true;
        

    }
    public void ResumeGame()
    {
        jin.gameObject.SetActive(true);
        jang.gameObject.SetActive(true);
        pauseMenu.enabled = false;
        sound.volume = 0.1f;
        isPaused = false;


    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
