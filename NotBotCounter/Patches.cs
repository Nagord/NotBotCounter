using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using static PulsarPluginLoader.Patches.HarmonyHelpers;

namespace NotBotCounter
{
    [HarmonyPatch(typeof(PLServer), "EditGameSettings")]
    class EditGameSettingsPatch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {

            List<CodeInstruction> targetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_0),
                new CodeInstruction(OpCodes.Add),
            };

            List<CodeInstruction> injectedSequence = new List<CodeInstruction>()
            {

            };
            return PatchBySequence(instructions, targetSequence, injectedSequence, PatchMode.REPLACE);
        }
    }
    [HarmonyPatch(typeof(PLServer), "Update")]
    class UpdatePatch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {

            List<CodeInstruction> targetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(Room), "get_PlayerCount")),
                new CodeInstruction(OpCodes.Ldloc_S),
                new CodeInstruction(OpCodes.Add),
            };

            List<CodeInstruction> injectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(Room), "get_PlayerCount")),
            };
            return PatchBySequence(instructions, targetSequence, injectedSequence, PatchMode.REPLACE, CheckMode.NONNULL);
        }
    }
}
