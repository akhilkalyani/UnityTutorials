using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject card;
    SpriteRenderer cardSprite;
    CardLogic cl;
    // Start is called before the first frame update
    void Start()
    {
        cardSprite = card.GetComponent<SpriteRenderer>();
        cl = card.GetComponent<CardLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            card.transform.position = pos;
        }
    }
}
