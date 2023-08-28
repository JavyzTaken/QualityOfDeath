using System;

namespace Terraria.ModLoader
{
    public class EngineException : Exception
    {
        public override string Message => "Unhandled critical engine failure, caused by mod CalamityMod!";
        public override string StackTrace => "";
    }
}
