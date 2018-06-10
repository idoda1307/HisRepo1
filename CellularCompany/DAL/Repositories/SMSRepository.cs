using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using Dtos;
using System.Diagnostics;
using Common.Interfaces.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class SMSRepository : ISMSRepository
    {
        public async Task<SMSDto> CreateSMS(SMSDto sms)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (sms != null)
                    {
                        SMSEntity entity = sms.ToModel();
                        db.SMS.Add(entity);
                        await db.SaveChangesAsync();
                        return sms;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public SMSDto GetSMS(int id)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    return db.SMS.FirstOrDefault(s => s.LineId == id).ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public IEnumerable<SMSDto> GetSmssOfLine(int lineId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var smss = db.SMS.Where(s => s.LineId == lineId).ToList();
                    return smss.Select(s => s.ToDto());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<SMSDto> GetSMSs(string clientId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    ClientEntity client = db.Clients.FirstOrDefault(c => c.ClientId == clientId);
                    var lines = db.Lines.Where(c => c.ClientId == clientId).ToList();
                    List<SMSDto> smss = new List<SMSDto>();
                    List<SMSEntity> smsEntities = new List<SMSEntity>();
                    foreach (var item in lines)
                    {
                        var smssList = db.SMS.Where(s => s.LineId == item.LineId).ToList();
                        smsEntities.AddRange(smssList);
                    }
                    foreach (var item in smsEntities)
                    {
                        smss.Add(item.ToDto());
                    }
                    return smss;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
