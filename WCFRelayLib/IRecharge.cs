using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFRelayLib
{
    [ServiceContract(Namespace = "https://recharge.servicebus.windows.net/rechargerelay")]
    public interface IRecharge
    {
        [OperationContract]
        string DoRecharge(string message);
    }

    interface IRechargeChannel : IRecharge, IClientChannel { }
}
