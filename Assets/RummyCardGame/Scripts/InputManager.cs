using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        CardManager.insatnce.MoveCard(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       if(eventData.pointerCurrentRaycast.gameObject!=null)
       {
            if(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>()!=null)
            {
                CardManager.insatnce.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
            }
       }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CardManager.insatnce.ReleaseCard();
    }
}
