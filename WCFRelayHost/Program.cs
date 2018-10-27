using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFRelayLib;

namespace WCFRelayHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string scheme = "sb";
            string serviceNamespace = "recharge";
            string servicePath = "https://recharge.servicebus.windows.net/rechargerelay";
            string policy = "RootManageSharedAccessKey";
            string accessKey = "Kn1GO+dihGWMbMLEe6DfsuxJd6ptgvfQVG6EF6GivdY=";

            Uri address = ServiceBusEnvironment.CreateServiceUri(scheme, serviceNamespace, servicePath);

            ServiceHost sh = new ServiceHost(typeof(Recharge),address);

            sh.AddServiceEndpoint(typeof(IRecharge), new NetTcpRelayBinding(),address)
                .Behaviors.Add(new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(policy, accessKey)
                });

            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }
    }
}
