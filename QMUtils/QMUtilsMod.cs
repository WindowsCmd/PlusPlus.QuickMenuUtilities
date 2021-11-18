using System;
using MelonLoader;


[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(QMUtils.QMUtilsMod), "QuickMenuUtils", "0.0.1", "Astrid")]
[assembly: MelonColor(ConsoleColor.Red)]

namespace QMUtils
{
    public class QMUtilsMod : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("QuickMenuUtils Starting..");

        }
    }
}
