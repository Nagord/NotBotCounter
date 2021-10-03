using PulsarModLoader;

namespace NotBotCounter
{
    public class Mod : PulsarMod
    {
        public override string Version => "1.0.1";

        public override string Author => "Dragon";

        public override string LongDescription => "Removes bots from the lobby player counter (allows players to join regardles of bots filling game)";

        public override string Name => "NotBotCounter";

        public override string HarmonyIdentifier()
        {
            return "Dragon.NotBotCounter";
        }
    }
}
