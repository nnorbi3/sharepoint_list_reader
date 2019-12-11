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
    public class Connecter
    {
        public string URL { get; }

        public string Username { get; }

        public SecureString Password { get; }

        public ClientContext client;

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
        /// Returns an error in case of failure.
        /// </summary>
        /// <returns>Error.</returns>
        public Error ConnectAndAuthenticate()
        {
            try
            {
                client = new ClientContext(URL);

                try
                {
                    try
                    {
                        client.Credentials =
                            new SharePointOnlineCredentials(Username, Password); // Online login
                        client.ExecuteQuery();
                    }
                    catch (NotSupportedException)
                    {
                        client.Credentials =
                            new NetworkCredential(Username, Password); // On-premise(local) login
                        client.ExecuteQuery();
                    }

                }
                catch (ClientRequestException)
                {
                    return new Error { Type = ErrorType.AuthenticationError, Message = "Something went wrong. Check your credentials" };
                }
                catch (IdcrlException)
                {
                    return new Error { Type = ErrorType.AuthenticationError, Message = "Incorrect username or password" };
                }
                catch (ArgumentException)
                {
                    return new Error { Type = ErrorType.AuthenticationError, Message = "Incorrect username. Username must be an e-mail address" };
                }
                catch (WebException)
                {
                    return new Error { Type = ErrorType.AuthenticationError, Message = "Something went wrong. Check your credentials" };
                }
            }
            catch (ArgumentException)
            {
                return new Error { Type = ErrorType.AuthenticationError, Message = "Requested site not found." };
            }



            return new Error { Type = ErrorType.OK };
        }
    }
}
