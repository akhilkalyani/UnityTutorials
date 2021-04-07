using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swipe;
public class DoSwipe : MonoBehaviour
{
    [SerializeField] RectTransform up;
    [SerializeField] RectTransform down;
    [SerializeField] RectTransform right;
    [SerializeField] RectTransform left;
    Vector2 currentPos;
    Vector2 finalPos;
    int count = 0;
    private void Awake()
    {
        currentPos = GetComponent<RectTransform>().position;
    }
    private void OnEnable()
    {
        SwipeInput.OnSwipe +=OnSwipePerformed;
    }

    private void OnSwipePerformed(SwipeDirection dir)
    {
        StopAllCoroutines();
        Debug.Log("direction "+dir);
        Move(dir);
    }
    private void Move(SwipeDirection dir)
    {
        switch(dir)
        {
            case SwipeDirection.Up:
                StartCoroutine(MovePlayer(currentPos,up.position));
                break;
            case SwipeDirection.Down:
                StartCoroutine(MovePlayer(currentPos, down.position));
                break;
            case SwipeDirection.Right:
                StartCoroutine(MovePlayer(currentPos, right.position));
                break;
            case SwipeDirection.Left:
                StartCoroutine(MovePlayer(currentPos, left.position));
                break;
        }
    }
    private IEnumerator MovePlayer(Vector3 currentPos,Vector3 endPos)
    {
        float t = 0;
        while(t<=1)
        {
            t += Time.deltaTime;
            GetComponent<RectTransform>().position = Vector3.Lerp(currentPos,endPos,t);
            yield return null;
        }
        yield return new WaitForSeconds(0.4f);
        GetComponent<RectTransform>().position = currentPos;
    }
    private void OnDisable()
    {
        SwipeInput.OnSwipe -= OnSwipePerformed;
    }
    void Update()
    {
        
    }
}
