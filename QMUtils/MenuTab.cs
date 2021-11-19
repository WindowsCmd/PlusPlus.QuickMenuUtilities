using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;

namespace QMUtils
{
    public class Tab
    {
        GameObject root;
        Image image;
        MenuTab tab;
        GameObject menuTabGameObject;

        public Tab(Transform parent, string name, string toolTip, Sprite icon = null)
        {
            root = UnityEngine.Object.Instantiate<GameObject>(UIElements.quickMenuBase, parent);
            root.name = name + "_quickMenuUtils";
            tab = root.gameObject.GetComponent<MenuTab>();
            image = root.transform.Find("Icon").GetComponent<Image>();
            image.sprite = icon;
            image.overrideSprite = icon;
            tab.GetComponent<StyleElement>().field_Private_Selectable_0 = tab.GetComponent<Button>();
            tab.GetComponent<Button>().onClick.AddListener((Action)(() => tab.GetComponent<StyleElement>().field_Private_Selectable_0 = tab.GetComponent<Button>()));
        }
    }
}
