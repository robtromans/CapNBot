using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapNBot
{
    class Program
    {
        static void Main(string[] args)
        {
            IrcClient irc = new IrcClient(
                ConfigurationManager.AppSettings["twitchDefaultIrcPath"],
                6667,
                ConfigurationManager.AppSettings["twitchOauthUsername"],
                ConfigurationManager.AppSettings["twitchOauthPassword"]
            );

            irc.joinChannel(ConfigurationManager.AppSettings["twitchChannel"]);

            while(true)
            {
                string message = irc.readMessage();
                if (message.Contains("!hello"))
                {
                    irc.sendChatMessage("Hey friend!");
                }
            }
        }
    }
}
