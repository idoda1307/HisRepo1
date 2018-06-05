using Client.InvoiceServiceReference;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public interface ISimulatorService
    {
        Task<IEnumerable<LineModel>> GetDestinationLines(int lineId);
        Task CreateCommunication(CommunicationModel communication, bool isSms,double duration);
    }
}
