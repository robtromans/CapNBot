using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CapNBot
{
    class IrcClient
    {

        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;

        private string channel;
        private string username;

        public IrcClient(string ip, int port, string username, string password)
        {
            tcpClient = new TcpClient(ip, port);
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());

            this.username = username;

            writer.WriteLine("PASS " + password);
            writer.WriteLine("NICK " + username);
            writer.WriteLine("USER " + username + " 8 * :" + username);
            writer.Flush();
        }

        public void joinChannel(string channel)
        {
            this.channel = channel;

            writer.WriteLine("JOIN #" + channel);
            writer.Flush();
        }

        public void sendIRCMessage(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }

        public void sendChatMessage(string message)
        {
            sendIRCMessage(":" + username + "!" + username + "@" + username 
                + ".tmi.twitch.tv PRIVMSG #" + channel + " :" + message);
        }

        public string readMessage()
        {
            string message = reader.ReadLine();
            return message;
        }
    }
}
