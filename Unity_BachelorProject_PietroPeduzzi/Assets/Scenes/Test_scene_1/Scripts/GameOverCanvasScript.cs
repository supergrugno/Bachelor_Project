using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject resetButton;

    private void Awake()
    {
        Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resetButton);
    }
}
