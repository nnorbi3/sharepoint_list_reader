using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SharepointLogic
    {
        private ClientContext client;

        public SharepointLogic(ClientContext client)
        {
            this.client = client;
        }

        public List<string> GetListNames()
        {
            List<string> lists = new List<string>();
            Web site = client.Web;
            ListCollection coll = site.Lists;
            IEnumerable<List> resultCollection = client.LoadQuery(
                coll.Include(
                    l => l.Title,
                    l => l.Id,
                    l => l.DefaultViewUrl,
                    l => l.BaseType).Where(l => l.BaseType == BaseType.GenericList && !l.Hidden)
            );
            client.Load(coll);
            client.ExecuteQuery();
            foreach (List l in resultCollection)
            {
                if (!l.DefaultViewUrl.Contains("PublishedFeed") &&
                    l.DefaultViewUrl.Contains("Lists"))
                {
                    lists.Add(l.Title);
                }
            }

            return lists;
        }
    }
}
