using RimToolsUI.ExtraWidgets;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace WorldSearch {

    // TODO: get input events and remove focus
    internal static class WorldSearchBar {
        private static Vector2 ScrollbarPosition;
        private static List<WorldObject> SearchResults;
        private static string SearchString;
        private static Dictionary<string, string> TruncatedNamesCache = new Dictionary<string, string>();
        private static float XPos = 10f;
        private static float YPos = 10f;

        static WorldSearchBar() {
            SearchResults = new List<WorldObject>();
        }

        internal static void DrawSeachBox() {
            Rect searchRect = new Rect(XPos, YPos, 250f, 26f);
            GUI.SetNextControlName("WorldSearchBox");
            string search = TextEntryWidgets.TextEntryWithPlaceHolder(searchRect, SearchString, "SearchPlaceholder".Translate(), true);

            if (search != SearchString) {
                SearchString = search;
                UpdateSearchResults();
            }
            DrawResults();
        }

        private static void Clear() {
            SearchString = string.Empty;
        }

        private static void DrawResults() {
            if (SearchResults != null) {
                float y = YPos + 30f;
                Rect outer = new Rect(XPos, y, 250f, UI.screenHeight - 240f);
                Rect inner = outer.ContractedBy(4f);
                inner.width -= 8f;
                inner.height = SearchResults.Count * 32f;

                Listing_Standard listing = new Listing_Standard(GameFont.Tiny);
                Widgets.BeginScrollView(outer, ref ScrollbarPosition, inner, true);
                listing.Begin(inner);
                foreach (var item in from i in SearchResults orderby i.Label select i) {
                    if (listing.ButtonText(string.Format("{0} [{1}]", item.Label, item.Faction.Name).Truncate(inner.width, TruncatedNamesCache), null, false)) {
                        CameraJumper.TryJumpAndSelect(item);
                    }
                }

                listing.End();
                Widgets.EndScrollView();
            }
        }

        private static void UpdateSearchResults() {
            TruncatedNamesCache.Clear();
            if (SearchString.NullOrEmpty()) {
                SearchResults.Clear();
            } else {
                var searchStringLowered = SearchString.ToLower();
                SearchResults = Current.Game.World.worldObjects.AllWorldObjects.FindAll(obj => obj.Label.ReplaceDiacritics().ToLower().Contains(searchStringLowered) || obj.Faction.Name.ReplaceDiacritics().ToLower().Contains(searchStringLowered));
            }
        }
    }
}