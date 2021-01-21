using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardView : MonoBehaviour
{
    private Image imageComponent;
    public int childIndex;
    private void Awake()
    {
        imageComponent = GetComponent<Image>();
    }
    public void SetImage(Sprite sprite)
    {
        imageComponent.sprite = sprite; 
    }
}
