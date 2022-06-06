using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject controlsCanvas;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Transform cameraPosition1;
    [SerializeField] private Transform cameraPosition2;

    [SerializeField] private string gameSceneName;

    [SerializeField] private GameObject playButton, backButton, creditsButton, controlsButton, backButton2;

    private void Start()
    {
        mainCamera.transform.position = cameraPosition1.position;
        mainCamera.transform.rotation = cameraPosition1.rotation;

        mainCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
        controlsCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton);

        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenCredits()
    {
        mainCamera.transform.position = cameraPosition2.position;
        mainCamera.transform.rotation = cameraPosition2.rotation;

        mainCanvas.SetActive(false);
        creditsCanvas.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backButton);
    }

    public void CloseCredits()
    {
        mainCamera.transform.position = cameraPosition1.position;
        mainCamera.transform.rotation = cameraPosition1.rotation;

        mainCanvas.SetActive(true);
        creditsCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void CloseCOntrols()
    {
        mainCamera.transform.position = cameraPosition1.position;
        mainCamera.transform.rotation = cameraPosition1.rotation;

        mainCanvas.SetActive(true);
        controlsCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsButton);
    }

    public void OpenControls()
    {
        mainCamera.transform.position = cameraPosition2.position;
        mainCamera.transform.rotation = cameraPosition2.rotation;

        mainCanvas.SetActive(false);
        controlsCanvas.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backButton2);
    }
}
