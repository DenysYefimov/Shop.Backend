using System.Collections.Generic;

namespace Shop.Application.Clients.Queries.GetClientList
{
    public class ClientListVm
    {
        public IList<ClientLookUpDto> Clients { get; set; }
    }
}
