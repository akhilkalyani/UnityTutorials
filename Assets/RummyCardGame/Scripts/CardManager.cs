using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardManager : MonoBehaviour
{
    public static CardManager insatnce;
    [SerializeField]private List<Sprite> cardSprites;
    [SerializeField] private GameObject cardHolder, cardPrefab, dummyCardPrefab,parentHolder;
    private int k;
    private CardView selectedCard;
    private GameObject dummyCardObj;
    public CardView SelectedCard { get => selectedCard;  }

    private void Awake()
    {
        if(insatnce==null)
        {
            insatnce = this;
        }
        cardHolder = this.gameObject;
    }
    private void Start()
    {
        for (int i = 0; i < 13; i++)
        {
            k = i;
            SpawnCard();
        }
    }
    public void SetSelectedCard(CardView card)
    {
        selectedCard = card;
        selectedCard.childIndex = card.transform.GetSiblingIndex();
        GetDummyCard().SetActive(true);
        GetDummyCard().transform.SetSiblingIndex(card.transform.GetSiblingIndex());
        selectedCard.transform.SetParent(parentHolder.transform);
    }
    public void MoveCard(Vector2 pos)
    {
        if(selectedCard!=null)
        {
            selectedCard.transform.position = pos;
        }
    }
    public void ReleaseCard()
    {
        if(selectedCard!=null)
        {
            GetDummyCard().SetActive(false);
            selectedCard.transform.SetParent(cardHolder.transform);
            selectedCard.transform.SetSiblingIndex(selectedCard.childIndex);
            GetDummyCard().transform.SetParent(parentHolder.transform);
            selectedCard = null;
        }
    }
    GameObject GetDummyCard()
    {
        if(dummyCardObj!=null)
        {
            if(dummyCardObj.transform.parent!=cardHolder.transform)
            {
                dummyCardObj.transform.SetParent(cardHolder.transform);
            }
            return dummyCardObj;
        }
        else
        {
            dummyCardObj = Instantiate(dummyCardPrefab);
            dummyCardObj.name = "DummyCard";
            dummyCardObj.transform.SetParent(cardHolder.transform);
        }
        return dummyCardObj;
    }
    void SpawnCard()
    {
        GameObject card = Instantiate(cardPrefab);
        card.name = "Card" + k;
        card.transform.SetParent(cardHolder.transform);
        card.GetComponent<CardView>().SetImage(cardSprites[k]);
    }
}
