using System;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        public int GetMoneyFromImperium()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(3000, 5000);
        }
    }
}
