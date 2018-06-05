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
    public class CallsRepository: ICallsRepository
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
                catch(Exception ex)
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

        public IEnumerable<CallsDto> GetCalls(string clientId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    ClientEntity client = db.Clients.FirstOrDefault(c => c.ClientId == clientId);
                    var lines = db.Lines.Where(c => c.ClientId == clientId).ToList();
                    List<CallsDto> calls = new List<CallsDto>();
                    List<CallsEntity> callEntities = new List<CallsEntity>();
                    foreach (var item in lines)
                    {
                        var callList = db.Calls.Where(s => s.LineId == item.LineId).ToList();
                        callEntities.AddRange(callList);
                    }
                    foreach (var item in callEntities)
                    {
                        calls.Add(item.ToDto());
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
    }
}
