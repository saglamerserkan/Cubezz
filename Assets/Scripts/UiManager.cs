using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject lm;
    [SerializeField] private GameObject pauseMenu;
    // [SerializeField] private Ease easeType = Ease.Linear;
    // [SerializeField] private float animSpeed = 0.5f;
    // [SerializeField] private Transform pauseMenuTarget;
    // [SerializeField] private Transform pauseMenuBG;

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        // pauseMenu.transform.DOMove(new Vector3(1.5f,3.5f,0f), animSpeed).SetEase(easeType);
        // pauseMenuBG.GetComponent<Image>().color.a = 1f;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        Destroy(lm.GetComponent<LevelManager>().thisLevel);
        //DestroyImmediate(lm.thisLevel);
        Instantiate(lm.GetComponent<LevelManager>().thisLevel, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}