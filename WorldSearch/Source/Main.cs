using HarmonyLib;
using System.Reflection;
using Verse;

namespace WorldSearch {
    public class Main : Mod {
        public Main(ModContentPack content) : base(content) {
            var harmony = new Harmony("com.scuba156.WorldSearch");

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}