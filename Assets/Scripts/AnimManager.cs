using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimManager : MonoBehaviour
{
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject levelBG;
    [SerializeField] private GameObject cardPreview;
    [SerializeField] private Ease easeType = Ease.Linear;
    [SerializeField] private float animSpeed = 0.5f;
    [SerializeField] private List<GameObject> mainCube;
    [SerializeField] private GameObject nextLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        // animSpeed *= Time.deltaTime;
        
        SetScaleZero();
        StartCoroutine(IncreaseScaleSize(0.1f));
        SliderStartAnim();
        LevelStartAnim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderStartAnim()
    {
        _slider.transform.localScale = Vector2.zero;
        _slider.transform.DOScale(new Vector2(4.5f, 4.5f), animSpeed).SetEase(easeType);
    }

    public void LevelStartAnim()
    {
        levelBG.transform.localScale = Vector2.zero;
        levelBG.transform.DOScale(new Vector2(0.6f, 0.6f), animSpeed).SetEase(easeType);
    }

    /// <summary>
    /// 3 tane de kullaninca comment satiri hojamm.
    /// </summary>
    public void SetScaleZero()
    {
        for (int i = 0; i < mainCube.Count; i++)
        {
            mainCube[i].transform.localScale = Vector3.zero;
        }
        cardPreview.transform.localScale = Vector3.zero;
        nextLevelButton.transform.localScale = Vector3.zero;
    }

    private IEnumerator IncreaseScaleSize(float time)
    {
        for (int i = 0; i < mainCube.Count; i++)
        {
            mainCube[i].transform.DOScale(new Vector3(1f, 1f, 1f), animSpeed).SetEase(easeType);
            cardPreview.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), animSpeed).SetEase(easeType);
            nextLevelButton.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), animSpeed).SetEase(easeType);
            yield return new WaitForSeconds(time);
            //Debug.Log("item returned");
        }
    }

    public void CardPreviewLevelAnim()
    {
        cardPreview.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), animSpeed).SetEase(easeType);
        // cardPreview.transform.position = Vector3.zero;
    }
}
