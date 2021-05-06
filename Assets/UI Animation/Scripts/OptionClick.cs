using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionClick : MonoBehaviour
{
    public Color defaultColor;
    private Image img;
    private void Awake()
    {
       img = GetComponent<Image>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        defaultColor = img.color;
        transform.GetComponentInChildren<Text>().text = this.name;
    }

    public void ChangeColor()
    {
        img.color = Color.blue;
    }
    public void ResetToDefaultColor()
    {
        img.color = defaultColor;  
    }
}
