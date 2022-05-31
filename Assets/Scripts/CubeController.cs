using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using DG.Tweening;

public class CubeController : MonoBehaviour
{
    // [SerializeField] private GameObject dragAndRotate;
    [SerializeField] private SliderManager _sliderManager;


    public Vector3 cubeTrueRotation;
    private bool singleCheck;

    public CubeFaceManager cfm;
    public List<SpriteRenderer> sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set Cube Sprites
        sprite[0].sprite = cfm.cubeFaces[0];
        sprite[1].sprite = cfm.cubeFaces[1];
        sprite[2].sprite = cfm.cubeFaces[2];
        sprite[3].sprite = cfm.cubeFaces[3];
        sprite[4].sprite = cfm.cubeFaces[4];
        sprite[5].sprite = cfm.cubeFaces[5];
    }

// Update is called once per frame
    void Update()
    {
        if (GetComponent<DragAndRotate>().isMove)
        {
            var rotation = transform.rotation.eulerAngles;
            Vector3 position = new Vector3(Mathf.Round(rotation.x), Mathf.Round(rotation.y), Mathf.Round(rotation.z));
            if (position == cubeTrueRotation && singleCheck == false)
            {
                StopRotation();
            }
        }
    }

    public void StopRotation()
    {
        GetComponent<DragAndRotate>().isComplate = true;
        GetComponent<DragAndRotate>().IsActive = false;
        singleCheck = true;
        _sliderManager.UpdateProgress();
        Debug.Log(gameObject + "donusumunu tamamladi");
    }
}