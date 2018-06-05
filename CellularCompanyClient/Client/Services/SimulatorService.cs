using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.InvoiceServiceReference;
using Client.CRMServiceReference;
using System.Diagnostics;
using Client.Infrastructure;

namespace Client.Services
{
    public class SimulatorService : ISimulatorService
    {
        InvoiceServiceClient invoice = new InvoiceServiceClient();

        public async Task<IEnumerable<LineModel>> GetDestinationLines(int lineId)
        {
            try
            {
                List<InvoiceServiceReference.LineDto> lines = await invoice.GetDestinationLinesAsync(lineId);
                var li= lines.Select(l => l.ToModel()).ToList();
                return li;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task CreateCommunication(CommunicationModel communication, bool isSms, double duration)
        {
            communication.Time = DateTime.Now;
            communication.LineId = communication.Line.LineId;
            if (isSms)
            {
                SMSDto sms = ModelExtensions.ToSms(communication);
                if (sms != null)
                    await invoice.AddSMSAsync(sms);
            }
            else
            {
                CallsDto call = ModelExtensions.ToCall(communication, duration);
                if (call != null)
                    await invoice.AddCallAsync(call);
            }
        }
    }
}
