using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.UI.Core;
using VRC.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Tooltips;
using VRC.UI.Elements.Menus;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using MelonLoader;

namespace QMUtils
{
    public class MenuPage
    {
        UIPage page;
        public GameObject gameObject { get; private set; }
        public RectTransform rectTransform { get; private set; }
        public VerticalLayoutGroup verticalLayoutGroup { get; private set; }
        public string pageName { get; private set; }
        public string title {  get; private set; }
        public Texture2D icon { get; private set; }
        public TextMeshProUGUI pageTitle { get; private set; }
        public RectMask2D mask { get; private set; }
        public Dictionary<string, ButtonGroup> buttonGroups = new Dictionary<string, ButtonGroup>();

        /// <summary>
        /// A new quick menu page
        /// </summary>
        /// <param name="name">Name of the menu</param>
        /// <param name="title">The title of the menu, this will be displayed above the page</param>
        public MenuPage(string name, string title)
        {
            gameObject = UnityEngine.Object.Instantiate<GameObject>(UIElements.quickMenuBase, UIElements.quickMenuBase.transform.parent);

            pageName = "Menu_" + name;
            gameObject.name = pageName;
            rectTransform = gameObject.GetComponent<RectTransform>();

            GameObject.Destroy(gameObject.GetComponent<UIPage>());

            GameObject.Destroy(rectTransform.Find("Header_H1/RightItemContainer/Button_QM_Expand").gameObject);

            verticalLayoutGroup = rectTransform.Find("ScrollRect/Viewport/VerticalLayoutGroup").GetComponent<VerticalLayoutGroup>();

            for (int i = verticalLayoutGroup.rectTransform.childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(verticalLayoutGroup.transform.GetChild(i).gameObject);
            }

            page = gameObject.AddComponent<UIPage>();
            page.field_Public_String_0 = name;
            page.field_Public_Boolean_1 = true;
            page.field_Private_MenuStateController_0 = UIElements.getMenuController();
            page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            page.field_Private_List_1_UIPage_0.Add(page);

            UIElements.getMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(name, page);

            List<UIPage> updatedUIPages = UIElements.getMenuController().field_Public_ArrayOf_UIPage_0.ToList<UIPage>();
            updatedUIPages.Add(page);
            UIElements.getMenuController().field_Public_ArrayOf_UIPage_0 = updatedUIPages.ToArray();

            pageTitle = rectTransform.Find("Header_H1/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>();
            pageTitle.text = title;

        }

        public ButtonGroup AddButtonGroup(string title)
        {
            ButtonGroup newButtonGroup = new ButtonGroup(title, this.verticalLayoutGroup.transform);
            buttonGroups.Add(title, newButtonGroup);
            return newButtonGroup;
        } 
    }
}
 