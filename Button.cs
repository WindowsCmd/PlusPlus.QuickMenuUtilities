using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QMUtils
{
    public class SimpleButton
    {
        public GameObject gameObject { get; private set; }
        public TextMeshProUGUI buttonText { get; private set; }


        public SimpleButton(string text, Transform parent, Action click, string toolTip)
        {
            gameObject = GameObject.Instantiate(UIElements.singleButtonBase, parent);
            buttonText = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();  
            buttonText.text = text;
        }
    }
}
