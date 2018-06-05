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
    public class LineRepository : ILineRepository
    {
        public async Task<LineDto> AddLineEntity(LineDto line, SelectedNumbersDto selectedNumbers)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (line != null && CheckIfLineNumberAlreadyExist(line.Number))
                    {
                        line.SelectedNumber = selectedNumbers;
                        LineEntity lineEntity = line.ToModel();
                        db.Lines.Add(lineEntity);
                        await db.SaveChangesAsync();
                        return line;
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

        public async Task<bool> DeleteLine(int lineId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var line = db.Lines.FirstOrDefault(l => l.LineId == lineId);
                    if (line != null)
                    {
                        var selectedNumbers = db.SelectedNumbers.FirstOrDefault(l => l.Id == line.LineId);
                        db.SelectedNumbers.Remove(selectedNumbers);
                        db.Lines.Remove(line);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public async Task<LineDto> UpdateLine(LineDto line, int lineId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (line != null && lineId != 0 && CheckIfLineNumberAlreadyExist(line.Number))
                    {
                        line.LineId = lineId;
                        LineEntity entity = line.ToModel();
                        db.Lines.Attach(entity);
                        foreach (var propName in db.Entry(entity).CurrentValues.PropertyNames)
                        {
                            if (propName != nameof(entity.LineId))
                            {
                                db.Entry(entity).Property(propName).IsModified = true;
                            }
                        }
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

        public LineDto GetLine(int lineId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    return db.Lines.FirstOrDefault(l => l.LineId == lineId).ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<LineDto> GetLines()
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var a= db.Lines.ToList();
                    return a.Select(l=>l.ToDto());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<string> GetLineSelectedNumbers(int lineId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    List<string> list = new List<string>();
                    SelectedNumbersEntity entity = db.SelectedNumbers.Where(s => s.Line.LineId == lineId).FirstOrDefault();
                    foreach (var propName in db.Entry(entity).CurrentValues.PropertyNames)
                    {
                        if (propName.EndsWith("Number"))
                        {
                            if (db.Entry(entity).Property(propName).CurrentValue != null)
                                list.Add(db.Entry(entity).Property(propName).CurrentValue.ToString());
                        }
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public bool CheckIfLineNumberAlreadyExist(string number)
        {
            using (var db = new CellularCompanyContext())
            {
                foreach (var item in db.Lines)
                {
                    if (item.Number == number)
                        return false;
                }
                return true;
            }
        }

        public PackageIncludesDto GetPackageIncludes(int packageIncludesId)
        {
            using (var db = new CellularCompanyContext())
            {
                try
                {
                    return db.PackageIncludes.FirstOrDefault(p => p.PackageIncludesId == packageIncludesId).ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public LineDto GetLineByNumber(string number)
        {
            using (var db = new CellularCompanyContext())
            {
                try
                {
                    return db.Lines.Where(l => l.Number == number).FirstOrDefault().ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<LineDto> GetClientLines(string clientId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    ClientEntity client = db.Clients.FirstOrDefault(c => c.ClientId == clientId);
                    List<LineEntity> lines = client.Lines.ToList();
                    var a= lines.Select(l => l.ToDto());
                    return a.ToList();
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