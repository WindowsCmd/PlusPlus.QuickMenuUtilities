using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.UI.Core;
using VRC.UI;
using VRC.UI.Elements;
using UnityEngine;
using TMPro;

namespace QMUtils
{
    public class MenuPage
    {
        UIPage page;
        
        GameObject basePageGameObject;
        Transform pageContent;
        string pageName;
        string title;
        Texture2D icon;
        TextMeshProUGUI pageTitle;

        public MenuPage(string name, string title)
        {
            basePageGameObject = UnityEngine.Object.Instantiate<GameObject>(UIElements.quickMenuBase, UIElements.quickMenuBase.transform.parent);
            pageName = "qmUtils_" + name;
            basePageGameObject.transform.SetSiblingIndex(5);
            basePageGameObject.SetActive(false);
            page = basePageGameObject.AddComponent<UIPage>();
            page.field_Public_String_0 = name;
            page.field_Public_Boolean_1 = true;
            page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            page.field_Private_List_1_UIPage_0.Add(page);
            UIElements.getMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(name, page);

            pageContent = basePageGameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            pageTitle = basePageGameObject.GetComponentInChildren<TextMeshProUGUI>(true);
            pageTitle.text = title; 
        }
    }
}
