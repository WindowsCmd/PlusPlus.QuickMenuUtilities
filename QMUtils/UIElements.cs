using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using VRC.UI.Elements;
using MelonLoader;

namespace QMUtils
{
    public static class UIElements
    {
        public static GameObject quickMenuBase;
        public static GameObject menuTabBase;

        public static MenuStateController getMenuController() {
            return GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)").GetComponent<MenuStateController>();
        }

        public static IEnumerator GetElements()
        {
            while (GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/") == null)
                yield return new WaitForEndOfFrame();

            quickMenuBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").gameObject;
            menuTabBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").gameObject;
        }
    }
}
