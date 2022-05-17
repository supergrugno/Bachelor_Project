using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject creditsCanvas;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Transform cameraPosition1;
    [SerializeField] private Transform cameraPosition2;

    [SerializeField] private string gameSceneName;

    [SerializeField] private GameObject playButton, backButton, creditsButton;

    private void Start()
    {
        mainCamera.transform.position = cameraPosition1.position;
        mainCamera.transform.rotation = cameraPosition1.rotation;

        mainCanvas.SetActive(true);
        creditsCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton);
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
}
