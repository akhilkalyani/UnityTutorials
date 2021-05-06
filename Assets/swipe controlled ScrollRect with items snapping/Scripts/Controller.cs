using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace SSR
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private string[] messages;
        [SerializeField] private TMP_Text msg;
        // Start is called before the first frame update
        private void OnEnable()
        {
            ScrollSnapRect.GetCurrentPage += OnPageChanged;
            msg.text = messages[0];
        }

        private void OnPageChanged(int page)
        {
            msg.text = messages[page];
        }

        private void OnDisable()
        {
            ScrollSnapRect.GetCurrentPage -= OnPageChanged;
        }
    }
}