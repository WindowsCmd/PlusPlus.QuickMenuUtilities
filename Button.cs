﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MelonLoader;

namespace QMUtils
{
    public class SimpleButton
    {
        public GameObject gameObject { get; private set; }
        public TextMeshProUGUI buttonText { get; private set; }
        public Button button { get; private set; }

        public SimpleButton(string text, Transform parent, Action click, string toolTip)
        {
            MelonLogger.Msg("WTF");
            gameObject = GameObject.Instantiate(UIElements.singleButtonBase, parent);
            buttonText = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            buttonText.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, -25f, 0f);
            buttonText.text = text;
            button = gameObject.GetComponentInChildren<Button>(true);
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(click);
            GameObject.Destroy(gameObject.transform.Find("Icon").gameObject);
            GameObject.Destroy(gameObject.transform.Find("Icon_Secondary").gameObject);
            gameObject.SetActive(true);
        }
    }
}
