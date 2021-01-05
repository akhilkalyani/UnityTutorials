using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SlotMachine
{
    public class SlotController : MonoBehaviour
    {
        public RectTransform slot1RectTransform;
        public RectTransform slot2RectTransform;
        public int noOfTimeTospinSlot;
        public delegate void SlotSpin(int noOftime);
        public static SlotSpin SlotspinEvent;
        // Start is called before the first frame update
        void Start()
        {
            
        }
        public void OnSpin()
        {
            SlotspinEvent(noOfTimeTospinSlot);
        }
       
    }
}

