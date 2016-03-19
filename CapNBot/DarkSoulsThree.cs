using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapNBot
{
    class DarkSoulsThree
    {
        private string response;
        private string releaseDate = "12/04/2016";

        public DarkSoulsThree(string command)
        {
            this.parseCommand(command);
        }

        public string getResponse()
        {
            return this.response;
        }

        private void parseCommand(string command)
        {
            if (command.Contains("how long") || command.Contains("when is"))
            {
                this.response = getDaysUntilRelease();
            }
            else
            {
                this.response = "Sorry, I do not know the answer.";
            }
        }

        private string getDaysUntilRelease()
        {
            DateTime release = DateTime.Parse(this.releaseDate);
            DateTime now = DateTime.Now;

            int days = (release - now).Days;

            if (days > 0)
            {
                if (days == 1)
                {
                    return "There is one day left until the release of Dark Souls 3.";
                }
                else
                {
                    return "There are " + days.ToString() + " days left until Dark Souls 3 is released.";
                }
            }

            return "It is already out, go and buy it now.";
        }
    }
}
