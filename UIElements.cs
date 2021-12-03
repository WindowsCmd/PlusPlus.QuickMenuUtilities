using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using UnityEngine;
using VRC.UI.Elements;
using MelonLoader;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib.XrefScans;
using UnhollowerBaseLib.Attributes;

namespace QMUtils
{
    public static class UIElements
    {
        public static GameObject quickMenuBase;
        public static GameObject menuTabBase;

        internal static MethodInfo _pushPage;
        internal static MethodInfo _removePage;

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

        internal static void UserInterfaceInit()
        {
            MethodInfo[] pageMethods = typeof(UIPage).GetMethods().Where(method => method.Name.StartsWith("Method_Public_Void_UIPage_") && !method.Name.Contains("_PDM_")).ToArray();

            _pushPage = pageMethods.First(method => CheckMethod(method, "Add"));
            _removePage = pageMethods.First(method => method != _pushPage);
        }

        internal static bool CheckMethod(MethodBase method, string methodName)
        {
            foreach (XrefInstance instance in XrefScanner.XrefScan(method))
            {
                MethodBase resolved = instance.TryResolve();

                if (instance.Type == XrefType.Method && resolved.Name.Contains(methodName))
                {
                    return true;
                } 
            }

            return false;
        }

        public static void GoToMenu(UIPage root, UIPage page)
        {
            
        }
    }
}
