using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject camera;
    CameraController camCon;
    public bool isPaused = false;
    public Image loadFade;
    public Animator pauseAnim;
    public GameObject confirmPanel;

    bool confirmRestart, confirmMenu, confirmExit;

    void Start()
    {
        Time.timeScale = 1f;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        camCon = camera.GetComponent<CameraController>();
    }


    public void LevelChooserBtn(string level)
    {
        if(level == "Default")
        {
            Admanager.Reset();
        }
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
        Animator anim = loadFade.GetComponent<Animator>();
        anim.SetBool("Fade", true);
    }

    public void RetryBtn()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        Animator anim = loadFade.GetComponent<Animator>();
        anim.SetBool("Fade", true);
    }

    public void BackBtn()
    {
        SceneManager.LoadSceneAsync("levelChooser", LoadSceneMode.Single);
        Animator anim = loadFade.GetComponent<Animator>();
        anim.SetBool("Fade", true);

    }
    public void NextBtn()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        Animator anim = loadFade.GetComponent<Animator>();
        anim.SetBool("Fade", true);
    }
    public void MuteBackgroundMusic()
    {
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseAnim.SetBool("pause", true);
        if(camCon != null) { camCon.Paused(); }
    }
    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseAnim.SetBool("pause", false);
        ConfirmationDenied();
        if (camCon != null) { camCon.Resumed(); }
        

    }

    public void Exit()
    {
        Application.Quit();
    }

    //Confirmation Based Action;
    public void waitForRestartConfirm()
    {
        confirmRestart = true;
        confirmPanel.SetActive(true);
    }
    public void waitForMenuConfirm()
    {
        confirmMenu = true;
        confirmPanel.SetActive(true);
    }
    public void waitForExitConfirm()
    {
        confirmExit = true;
        confirmPanel.SetActive(true);
    }

    public void confirmedAction()
    {
        if (confirmRestart)
        {
            RetryBtn();
        }
        if (confirmMenu)
        {
            LevelChooserBtn("Default");
        }
        if (confirmExit)
        {
            Application.Quit();
        }
        confirmPanel.SetActive(false);
    }

    public void ConfirmationDenied()
    {
        confirmRestart = false;
        confirmMenu = false;
        confirmExit = false;
        confirmPanel.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "levelChooser")
        {
            if (Input.GetKey("escape"))
            {
                Admanager.Reset();
                SceneManager.LoadScene("Default", LoadSceneMode.Single);
            }
        }
        
    }
	
}
