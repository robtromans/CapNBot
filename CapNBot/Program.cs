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
            
            try
            {
                while (true)
                {
                    string message = irc.readMessage();
                    if (message.Contains("!hello"))
                    {
                        irc.sendChatMessage("Hey friend!");
                    }

                    if (message.Contains("dark souls"))
                    {
                        DarkSoulsThree DarkSoulsThree = new DarkSoulsThree(message);
                        irc.sendChatMessage(DarkSoulsThree.getResponse());
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine();
                Console.WriteLine("Failed to connect. Is the bot account active?");
                Console.WriteLine("1) Try adding the bot to a chat window from within the browser.");
                Console.WriteLine("2) Check that all of the bots credentials are correct.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Hit enter to close.");
                Console.ReadLine();
            }
        }
    }
}
