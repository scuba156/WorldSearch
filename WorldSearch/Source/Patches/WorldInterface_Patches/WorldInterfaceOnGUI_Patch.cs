using Harmony;
using RimWorld.Planet;

namespace WorldSearch.Patches.WorldInterface_Patches {

    [HarmonyPatch]
    [HarmonyPatch(typeof(WorldGlobalControls))]
    [HarmonyPatch("WorldGlobalControlsOnGUI")]
    public static class WorldInterfaceOnGUI_Patch {

        public static void Prefix() {
            WorldSearchBar.DrawSeachBox();
        }
    }
}