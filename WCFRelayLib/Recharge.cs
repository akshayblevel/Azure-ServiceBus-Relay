using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFRelayLib
{
    public class Recharge : IRecharge
    {
        public string DoRecharge(string message)
        {
            return "Recharge is done for: " + message;
        }
    }
}
