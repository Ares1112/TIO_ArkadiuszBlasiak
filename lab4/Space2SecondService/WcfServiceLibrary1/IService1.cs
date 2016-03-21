using System.ServiceModel;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int GetMoneyFromImperium();
    }
}
