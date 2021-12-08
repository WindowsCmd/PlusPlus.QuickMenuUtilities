using System;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.Runtime;
using MelonLoader;

[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(QMUtils.QMUtilsMod), "QuickMenuUtilities", "0.0.2", "Astrid")]
[assembly: MelonColor(ConsoleColor.Red)]

namespace QMUtils
{
    public class QMUtilsMod : MelonMod
    {
        public bool usingTestingMode;
        public bool isInitalized = false;

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
         
            if (usingTestingMode == true)
            {
                if (buildIndex != -1)
                    return;

                MenuPage testPage = new MenuPage("debugTools", "++ Debug Tools");
                new Tab(UIElements.menuTabBase.transform.parent, "debugTools", "QMU Debugging menu V0.0.2");

                ButtonGroup buttonGroup = testPage.AddButtonGroup("uwu");

                SimpleButton button = new SimpleButton("UwU", buttonGroup.gameObject.transform, delegate() { MelonLogger.Msg("Clicked debug button "); }, "Test tool tip");

                MelonLogger.Msg($"Button Active: {button.gameObject.active} Button Name: {button.gameObject.name} Button Position: {button.gameObject.transform.position}");
            }
        }
    }
}
