using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI.Elements;

namespace QMUtils
{
    public static class UIElements
    {
        public static GameObject quickMenuBase;

        public static IEnumerator GetElements()
        {
            while(GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/") == null)
                yield return new WaitForEndOfFrame();

            quickMenuBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu/Container/Window/QMParent/Menu_Dashboard").gameObject;
        }
    }
}
