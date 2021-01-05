using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using SlotMachine;
using UnityEngine.UI;
public class SlotSpinner : MonoBehaviour
{
    public int stepsForSpin = 0;
    private float initialYpos = 0.0f;
    private int intervalBetweenSlotImage=160;
    private float yLimit = 0f;
    private RectTransform slotRecttransform;
    public float timeInterval = 0.025f;
    private int spinRound = 0;
    public Sprite[] slotImageArray;
    public Image slotImage;
    [SerializeField]private Image[] childSlots;
    private void Awake()
    {
        childSlots = GetComponentsInChildren<Image>();
    }
    private void OnEnable()
    {
        slotRecttransform = GetComponent<RectTransform>();
        initialYpos = slotRecttransform.anchoredPosition.y;
        stepsForSpin =  transform.childCount * 2 - 2;
        yLimit = initialYpos + (intervalBetweenSlotImage * stepsForSpin);
        Debug.Log(initialYpos+"--"+yLimit+" -->"+this.name);
        SlotController.SlotspinEvent += SpinSlot;
    }
    void SpinSlot(int noOftimeToSpinSlot)
    {
        spinRound = 0;
        for (int i = 1; i <childSlots.Length; i++)
        {
            childSlots[i].gameObject.SetActive(true);
        }
        slotImage.gameObject.SetActive(false);
        StartCoroutine(Spin(noOftimeToSpinSlot));
    }
    IEnumerator Spin(int noOfTimeSpinASlot)
    {
        while (spinRound< noOfTimeSpinASlot)
        {
            if (slotRecttransform.anchoredPosition.y >= yLimit) {
                spinRound++;
                slotRecttransform.anchoredPosition = new Vector2(slotRecttransform.anchoredPosition.x,initialYpos);
            }
            slotRecttransform.anchoredPosition = new 
                Vector2(slotRecttransform.anchoredPosition.x,slotRecttransform.anchoredPosition.y+intervalBetweenSlotImage);
            yield return new WaitForSeconds(timeInterval);
        }
        for (int i = 1; i <childSlots.Length; i++)
        {
            childSlots[i].gameObject.SetActive(false);
        }
        slotImage.gameObject.SetActive(true);
        slotImage.sprite = slotImageArray[Random.Range(0, slotImageArray.Length)];
    }
    private void OnDisable()
    {
        SlotController.SlotspinEvent -= SpinSlot;
    }
}
