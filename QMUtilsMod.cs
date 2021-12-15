/*
 
    QuickMenuUtils 
    Written by Astrid#8008 for PlusPlus (da best client eber)
    Made with lots nd lots of <3
    
    https://vrcplus.xyz/about
*/

using System;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.Runtime;
using MelonLoader;

[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(QMUtils.QMUtilsMod), "QuickMenuUtilities", "0.1.4", "Astrid")]
[assembly: MelonColor(ConsoleColor.Red)]

namespace QMUtils
{
    public class QMUtilsMod : MelonMod
    {
        public bool usingTestingMode;
        public bool isInitalized = false;
        public string QuickMenuModVersion = "0.1.4";
        public string noteForDecompilers = "If you want to know how we did this, or if your interested in creating things for vrchat work for us! https://vrcplus.xyz/jobs";

        public override void OnApplicationStart()
        {

            string[] cmdArgs = Environment.GetCommandLineArgs();

            MelonLogger.Msg("QuickMenuUtils Starting..");
            MelonLogger.Msg("QMU is still in early alpha! if you see any bugs please report them here: https://qmu.squadw.xyz/bugs");

            if (cmdArgs.Contains("--quickMenu.testingMode"))
            {
                usingTestingMode = true;
                MelonLogger.Msg("QMU has started in developer debugging mode (*^_^*)");
            }

            MelonCoroutines.Start(GetAssembly());
        }

        private void OnVRCUiManagerInit()
        {
            MelonLogger.Msg("Ui Initalized");
            MelonCoroutines.Start(UIElements.GetElements());
            UIElements.UserInterfaceInit();
        }

        private IEnumerator GetAssembly()
        {
            Assembly assembly;

            while(true)
            {
                assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(assembly_ => assembly_.GetName().Name == "Assembly-CSharp");
                if (assembly == null)
                    yield return null;
                else break;
            }

            MelonCoroutines.Start(VRCUIManagerInit(assembly));
        }

        private IEnumerator VRCUIManagerInit(Assembly assemblyCSharp)
        {
            Type vrcUIManager = assemblyCSharp.GetType("VRCUiManager");
            PropertyInfo uiManagerSingleton = vrcUIManager.GetProperties().First(prop_info => prop_info.PropertyType == vrcUIManager);
            while (uiManagerSingleton.GetValue(null) == null) yield return null;
            OnVRCUiManagerInit();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
         
            if (usingTestingMode == true && isInitalized == false)
            {
                if (buildIndex != -1)
                    return;

                MenuPage testPage = new MenuPage("debugTools", "++ Debug Tools");

                MenuPage testSubMenu = new MenuPage("debugSubmenu", "Submenu");

                new Tab(UIElements.menuTabBase.transform.parent, "debugTools", "QMU Debugging menu V0.0.2");

                ButtonGroup buttonGroup = testPage.AddButtonGroup("uwu");

                SimpleButton button = new SimpleButton("Open test submenu", buttonGroup.gameObject.transform, delegate ()
                {
                    testSubMenu.Open();

                }, "Test tool tip");

                /* SimpleButton testSubMenuButton = new SimpleButton("Test", subMenuButtonGroup.gameObject.transform, delegate ()
                {
                    MelonLogger.Msg("Here!");
                    \
                }," tool tip"); */

                
                MelonLogger.Msg($"Button Active: {button.gameObject.active} Button Name: {button.gameObject.name} Button Position: {button.gameObject.transform.position}");

                isInitalized = true;
            }
        }
    }
}
