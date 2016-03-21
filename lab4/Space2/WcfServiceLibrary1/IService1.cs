using CosmicAdventureDTO;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void InitializeGame();
        [OperationContract]
        Starship sendStarship(Starship starship, string systemName);
        [OperationContract]
        SSystem GetSystem();
        [OperationContract]
        Starship GetStarship(int money);

    }
}
