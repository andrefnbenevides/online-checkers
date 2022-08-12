using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCheckers.Shared
{
    public class Game
    {
        public string GameId { get; set; }
        public string WhitePlayerId { get; set; }
        public string BlackPlayerId { get; set; }
        public int PlayerCounter
        {
            get
            {
                return (string.IsNullOrEmpty(WhitePlayerId) ? 0 : 1) + (string.IsNullOrEmpty(BlackPlayerId) ? 0 : 1);
            }
        }
    }
}
