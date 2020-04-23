using HarmonyLib;
using RimWorld.Planet;

namespace WorldSearch.Patches.WorldInterface_Patches {
    [HarmonyPatch]
    [HarmonyPatch(typeof(WorldGlobalControls), "WorldGlobalControlsOnGUI")]
    public static class WorldInterfaceOnGUI_Patch {
        public static void Postfix() {
            WorldSearchBar.DrawSeachBox();
        }
    }
}