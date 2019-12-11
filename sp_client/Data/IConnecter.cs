using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IConnecter
    {
        string GetURL();
        string GetUsername();
        ClientContext Client { get; set; }
        void ConnectAndAuthenticate();
    }
}
