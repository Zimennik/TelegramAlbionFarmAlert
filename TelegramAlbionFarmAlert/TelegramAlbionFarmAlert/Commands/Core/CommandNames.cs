using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TelegramAlbionFarmAlert.Commands.Core
{
    public static class CommandNames
    {
        public const string CreateIsland = "/create_island";
        public const string Help = "/help";
        public const string Cancel = "/cancel";
        public const string GetIslands = "/get_islands";
        public const string CreateTimer = "/create_timer";
    }
}
