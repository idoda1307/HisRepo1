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
    public class CallsRepository : ICallsRepository
    {
        public async Task<CallsDto> CreateCall(CallsDto call)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (call != null)
                    {
                        CallsEntity entity = call.ToModel();
                        db.Calls.Add(entity);
                        await db.SaveChangesAsync();
                        return entity.ToDto();
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

        public CallsDto GetCall(int id)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    return db.Calls.FirstOrDefault(c => c.CallId == id).ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<CallsDto> GetCalls(int lineId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var calls = db.Calls.Where(l => l.LineId == lineId).ToList();
                    return calls.Select(c => c.ToDto());

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<CallsDto> GetCallsOfClient(string clientId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var lines = db.Lines.Where(l => l.ClientId == clientId).ToList();
                    List<CallsDto> calls = new List<CallsDto>();
                    foreach (var item in lines)
                    {
                        var lineCalls = db.Calls.Where(c => c.LineId == item.LineId).Select(c=>c.ToDto()).ToList();
                        calls.AddRange(lineCalls);
                    }
                    return calls;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public double GetNumberOfMinutes(LineDto line,PackageIncludesDto packageIncludes)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    double minutes = db.Calls.Where(l => l.LineId == line.LineId).Sum(l => l.Duration);
                    if (minutes >= packageIncludes.MaxMinute)
                        return minutes - packageIncludes.MaxMinute;
                    else return 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
    }
}
