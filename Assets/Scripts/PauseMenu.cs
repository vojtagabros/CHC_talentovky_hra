using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public AudioSource Soundtrack;

    // Update is called once per frame
    
    void Start()
    {
        PauseMenuUI.SetActive(false);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Soundtrack.Play();

    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Soundtrack.Pause();
    }

}