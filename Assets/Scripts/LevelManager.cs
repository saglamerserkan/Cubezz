using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Mathematics;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject nextLevelButton;

    [SerializeField] private Slider _slider;
    private bool justOnce;

    [SerializeField] private GameObject cardPreview;
    [SerializeField] private Ease easeType = Ease.Linear;
    [SerializeField] private float animSpeed = 0.5f;
    [SerializeField] private RectTransform cardRectTransform;

    [SerializeField] private GameObject confetti;

    // [SerializeField] private GameObject[] _level;
    // public bool levelSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        nextLevelButton.SetActive(false);
        confetti.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!justOnce)
        {
            CheckComplateLevel();
        }
    }

    void CheckComplateLevel()
    {
        if (_slider.value == 4)
        {
            Debug.Log("Level Complate");
            justOnce = true;
            LevelAnim();
            confetti.SetActive(true);
            // Instantiate(confetti, new Vector3(0f, 0f, 0f), quaternion.identity);
        }
    }

    public void NextLevel()
    {
        DestroyGameObject();
        Instantiate(nextLevel, new Vector3(0f, 0f, 0f), quaternion.identity);
    }

    public void LevelAnim()
    {
        nextLevelButton.SetActive(true);
        cardPreview.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), animSpeed).SetEase(easeType);
        cardRectTransform.localPosition = Vector3.zero;
    }

    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}