using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.RepositoryInterfaces
{
    public interface ISMSRepository
    {
        Task<SMSDto> CreateSMS(SMSDto sms);
        SMSDto GetSMS(int id);
        IEnumerable<SMSDto> GetSMSs(string clientId);
    }
}
