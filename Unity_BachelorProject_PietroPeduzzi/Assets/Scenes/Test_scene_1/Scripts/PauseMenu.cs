using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    private bool escMenuOpen = false;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject resumeButton;

    private void Start()
    {
        escMenuOpen = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Esc") && !escMenuOpen)
        {
            escMenuOpen = true;
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(resumeButton);

        }
        else if(Input.GetButtonDown("Esc") && escMenuOpen)
        {
            escMenuOpen = false;
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ClosePauseMenu()
    {
        escMenuOpen = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        escMenuOpen = false;
        SceneManager.LoadScene("GameScene");
    }
}
