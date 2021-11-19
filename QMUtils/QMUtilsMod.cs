using System;
using System.Linq;
using System.Runtime;
using MelonLoader;

[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(QMUtils.QMUtilsMod), "QuickMenuUtils", "0.0.1", "Astrid")]
[assembly: MelonColor(ConsoleColor.Red)]

namespace QMUtils
{
    public class QMUtilsMod : MelonMod
    {
        public bool usingTestingMode;

        public override void OnApplicationStart()
        {

            string[] cmdArgs = Environment.GetCommandLineArgs();

            MelonLogger.Msg("QuickMenuUtils Starting..");

            if (cmdArgs.Contains("--quickMenu.testingMode"))
            {
                usingTestingMode = true;
                MelonLogger.Msg("Quick menu utils has started in developer debugging mode (*^_^*)");
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonCoroutines.Start(UIElements.GetElements());
         
            if (usingTestingMode == true)
            {
                if(buildIndex != -1)
                {
                    MelonLogger.Msg("aaaaa fuck");
                    
                    MelonLogger.Msg(UIElements.quickMenuBase.name);
                    new MenuPage("mainTestingPage", "uwu");
                    new Tab(UIElements.quickMenuBase.transform.parent, "uwu", "uwu");
                }
            }
        }
    }
}
