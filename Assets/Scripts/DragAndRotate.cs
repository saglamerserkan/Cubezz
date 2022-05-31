using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragAndRotate : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    [SerializeField] private bool isActive = false;


    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    private float _length = 0.5f;
    public bool isMove = false;
    public bool isComplate = false;

    // Update is called once per frame
    void Update()
    {
        if (!isComplate)
        {
            if (Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);
                if (isMove == false)
                {
                    if (t is {phase: TouchPhase.Began})
                    {
                        //save began touch 2d point
                        firstPressPos = new Vector2(t.position.x, t.position.y);
                    }

                    if (t is {phase: TouchPhase.Ended})
                    {
                        if (isActive)
                        {
                            // isMove = true;


                            //save ended touch 2d point
                            secondPressPos = new Vector2(t.position.x, t.position.y);


                            //create vector from the two points
                            currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x,
                                secondPressPos.y - firstPressPos.y);
                            //normalize the 2d vector
                            currentSwipe.Normalize();
                            Debug.Log(currentSwipe.x + " " + currentSwipe.y);

                            if (secondPressPos == firstPressPos)
                            {
                                isMove = false;
                                isActive = false;
                                return;
                            }

                            // Debug.Log("Current Swipe " + currentSwipe);
                            //swipe upwards
                            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                            {
                                isMove = true;
                                transform.DOLocalRotate(new Vector3(+90, 0, 0), _length,
                                    RotateMode.WorldAxisAdd).OnComplete(AnimComplete);
                                // Debug.Log("swipe upwards");
                            }

                            //swipe down
                            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                            {
                                isMove = true;
                                transform.DOLocalRotate(new Vector3(-90, 0, 0), _length,
                                    RotateMode.WorldAxisAdd).OnComplete(AnimComplete);
                                // Debug.Log("swipe down");
                            }

                            //swipe left
                            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                            {
                                isMove = true;
                                transform.DOLocalRotate(new Vector3(0, +90, 0), _length,
                                    RotateMode.WorldAxisAdd).OnComplete(AnimComplete);
                                // Debug.Log("swipe left");
                            }

                            //swipe right
                            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                            {
                                isMove = true;
                                transform.DOLocalRotate(new Vector3(0, -90, 0), _length,
                                    RotateMode.WorldAxisAdd).OnComplete(AnimComplete);
                                //Debug.Log("swipe right");
                            }
                        }

                        //isMove = false;
                        isActive = false;
                    }
                }
            }
        }
    }

    public void AnimComplete()
    {
        isMove = false;
    }
}