using Harmony;
using System.Reflection;
using Verse;

namespace WorldSearch {

    public class Main : Mod {
        public HarmonyInstance HarmonyInst = HarmonyInstance.Create("com.scuba156.WorldSearch");

        public Main(ModContentPack content) : base(content) {
            HarmonyInst.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}