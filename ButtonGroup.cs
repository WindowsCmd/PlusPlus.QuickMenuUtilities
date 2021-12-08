using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace QMUtils
{
    public class ButtonGroup
    {
        public GameObject gameObject { get; private set; }
        public TextMeshProUGUI headerText { get; private set; }
        public GameObject headerGameObject { get; private set; } 
        
        public ButtonGroup(string title, Transform parent)
        {
            headerGameObject = GameObject.Instantiate(UIElements.buttonGroupHeader, parent);
            headerText = headerGameObject.transform.Find("LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>();
            headerText.text = title;
            gameObject = GameObject.Instantiate(UIElements.buttonGroupBase, parent);

            for(int i = gameObject.transform.childCount - 1; i >= 0; i--)
            {
                GameObject.DestroyImmediate(gameObject.transform.GetChild(i).gameObject);
            }
        }

        public SimpleButton AddSimpleButton(string text, Action onClick, string toolTip) 
        {
            SimpleButton newButton = new SimpleButton(text, this.gameObject.transform, onClick, toolTip);
            return newButton;
        }

    }
}
