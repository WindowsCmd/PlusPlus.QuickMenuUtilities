using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VRC.UI.Elements;
using VRC.UI.Core;
using MelonLoader;

namespace QMUtils
{
    public class SubMenu
    {
        public UIPage uiPage { get; private set; }
        public GameObject gameObject { get; private set; }
        public string title { get; private set; }
        public RectTransform rectTransform { get; private set; }
        public VerticalLayoutGroup verticalLayoutGroup { get; private set; }
        public RectMask2D mask { get; private set; }

        [Obsolete("Depricated in favor of just using a menupage")]
        public SubMenu(string name, string toolTip, bool backButtonEnabled = true, bool exportButonEnabled = false, Action exportButtonAction = null)
        {
            gameObject = GameObject.Instantiate(UIElements.subMenuBase, UIElements.menuBase.transform);
            rectTransform = gameObject.GetComponent<RectTransform>();
            gameObject.transform.SetSiblingIndex(5);
            gameObject.SetActive(false);
            gameObject.name = "SubMenu_" + name;


            GameObject.DestroyImmediate(gameObject.GetComponent<UIPage>());

            uiPage = gameObject.AddComponent<UIPage>();
            uiPage.field_Public_String_0 = name;
            uiPage.field_Public_Boolean_1 = true;
            uiPage.field_Private_MenuStateController_0 = UIElements.getMenuController();
            uiPage.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            uiPage.field_Private_List_1_UIPage_0.Add(uiPage);

            UIElements.getMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(name, uiPage);

            mask = verticalLayoutGroup.transform.parent.GetComponent<RectMask2D>();
            mask.enabled = true;

        }

        public void Open()
        {
            UIElements.getMenuController().Method_Public_Void_String_UIContext_Boolean_0(uiPage.field_Public_String_0);
        }
    }
}
