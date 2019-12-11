using Exceptions;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Connecter : IConnecter
    {
        private string URL { get; }
        private string Username { get; }
        private SecureString Password { get; }
        public ClientContext Client { get; set; }

        public Connecter(string url, string username, string password)
        {
            URL = url.Trim();
            Username = username.Trim();
            Password = new SecureString();
            foreach (char c in password)
            {
                this.Password.AppendChar(c);
            }
        }

        /// <summary>
        /// Connects the client to the given URL.
        /// Throws an error in case of failure.
        /// </summary>
        public void ConnectAndAuthenticate()
        {
            try
            {
                Client = new ClientContext(URL);

                try
                {
                    try
                    {
                        Client.Credentials =
                            new SharePointOnlineCredentials(Username, Password); // Online login
                        Client.ExecuteQuery();
                    }
                    catch (NotSupportedException)
                    {
                        Client.Credentials =
                            new NetworkCredential(Username, Password); // On-premise(local) login
                        Client.ExecuteQuery();
                    }

                }
                catch (ClientRequestException)
                {
                    throw new Error(ErrorType.AuthenticationError, "Something went wrong. Check your credentials!");
                }
                catch (IdcrlException)
                {
                    throw new Error(ErrorType.AuthenticationError, "Incorrect username or password.");
                }
                catch (ArgumentException)
                {
                    throw new Error(ErrorType.AuthenticationError, "Incorrect username. Username must be an e-mail address!");
                }
                catch (WebException)
                {
                    throw new Error(ErrorType.AuthenticationError, "Something went wrong. Check your credentials.");
                }
            }
            catch (ArgumentException)
            {
                throw new Error(ErrorType.AuthenticationError, "Requested site not found.");
            }
        }

        public string GetURL()
        {
            return this.URL;
        }

        public string GetUsername()
        {
            return this.Username;
        }
    }
}
