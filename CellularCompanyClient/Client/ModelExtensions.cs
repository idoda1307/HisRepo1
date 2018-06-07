using Client.CRMServiceReference;
using Client.InvoiceServiceReference;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class ModelExtensions
    {
        //public static CallsModel ToModel(this CallsDto call)
        //{
        //    return new CallsModel()
        //    {
        //        CallId = call.CallId,
        //        DestinationNumber = call.DestinationNumber,
        //        Duration = call.Duration,
        //        ExternalPrice = call.ExternalPrice,
        //        LineId = call.LineId,
        //        //Line = call.Line.ToModel(),
        //        Time = call.Time
        //    };
        //}

        //public static CallsDto ToDto(this CallsModel call)
        //{
        //    return new CallsDto()
        //    {
        //        CallId = call.CallId,
        //        DestinationNumber = call.DestinationNumber,
        //        Duration = call.Duration,
        //        ExternalPrice = call.ExternalPrice,
        //        LineId = call.LineId,
        //        //Line = call.Line.ToDto(),
        //        Time = call.Time
        //    };
        //}

        public static ClientModel ToModel(this CRMServiceReference.ClientDto client)
        {
            if (client == null) return null;
            return new ClientModel()
            {
                Address = client.Address,
                ClientId = client.ClientId,
                ClientTypeId = client.ClientTypeId,
                ContactNumber = client.ContactNumber,
                FirstName = client.FirstName,
                LastName = client.LastName,
                ClientType = client.ClientType.ToModel(),
                CallsToCenter = client.CallsToCenter
                //Payments = client.Payments.Select(p => p.ToModel()).ToList(),
                //Lines = client.Lines.Select(s => s.ToModel()).ToList()
            };
        }

        public static CRMServiceReference.ClientDto ToDto(this ClientModel client)
        {
            if (client == null) return null;
            CRMServiceReference.ClientDto client1 = new CRMServiceReference.ClientDto()
            {
                Address = client.Address,
                ClientId = client.ClientId,
                ClientTypeId = client.ClientType.ClientTypeId,
                ContactNumber = client.ContactNumber,
                FirstName = client.FirstName,
                LastName = client.LastName,
                CallsToCenter = client.CallsToCenter
                //ClientType = client.ClientType.ToDto()
                //Lines = client.Lines.Select(l => l.ToDto()).ToList(),
                //Payments = client.Payments.Select(p => p.ToDto()).ToList()
            };
            return client1;
        }

        public static ClientTypeModel ToModel(this CRMServiceReference.ClientTypeDto clientType)
        {
            if (clientType == null) return null;
            return new ClientTypeModel()
            {
                ClientTypeId = clientType.ClientTypeId,
                MinutePrice = clientType.MinutePrice,
                SMSPrice = clientType.SMSPrice,
                TypeName = clientType.TypeName
                //Clients = clientType.Clients.Select(c => c.ToModel()).ToList()
            };
        }

        public static ClientTypeModel ToModel1(this InvoiceServiceReference.ClientTypeDto clientType)
        {
            if (clientType == null) return null;
            return new ClientTypeModel()
            {
                ClientTypeId = clientType.ClientTypeId,
                MinutePrice = clientType.MinutePrice,
                SMSPrice = clientType.SMSPrice,
                TypeName = clientType.TypeName
                //Clients = clientType.Clients.Select(c => c.ToModel()).ToList()
            };
        }

        public static CRMServiceReference.ClientTypeDto ToDto(this ClientTypeModel clientType)
        {
            if (clientType == null) return null;
            return new CRMServiceReference.ClientTypeDto()
            {
                ClientTypeId = clientType.ClientTypeId,
                MinutePrice = clientType.MinutePrice,
                SMSPrice = clientType.SMSPrice,
                TypeName = clientType.TypeName,
                //Clients = clientType.Clients.Select(c => c.ToDto()).ToList()
            };
        }

        public static LineModel ToModel(this CRMServiceReference.LineDto line)
        {
            if (line == null) return null;
            return new LineModel()
            {
                ClientId = line.ClientId,
                LineId = line.LineId,
                Number = line.Number,
                Status = line.Status,
                PackageId =line.PackageId,
                SelectedNumberId = line.SelectedNumberId
                //Calls = line.Calls.Select(c => c.ToModel()).ToList(),
                //Client = line.Client.ToModel(),
                //Package = line.Package.ToModel(),
                //PackageIncludesId=line.PackageIncludeId
                //SMS = line.SMS.Select(s => s.ToModel()).ToList()
            };
        }

        public static LineModel ToModel(this InvoiceServiceReference.LineDto line)
        {
            if (line == null) return null;
            return new LineModel()
            {
                ClientId = line.ClientId,
                LineId = line.LineId,
                Number = line.Number,
                PackageId = line.PackageId,
                SelectedNumberId = line.SelectedNumberId
                //Calls = line.Calls.Select(c => c.ToModel()).ToList(),
                //Client = line.Client.ToModel(),
                //Package = line.Package.ToModel(),
                //PackageIncludesId=line.PackageIncludeId
                //SMS = line.SMS.Select(s => s.ToModel()).ToList()
            };
        }

        public static CRMServiceReference.LineDto ToDto(this LineModel line)
        {
            if (line == null) return null;
            return new CRMServiceReference.LineDto()
            {
                ClientId = line.ClientId,
                LineId = line.LineId,
                Number = line.Number,
                PackageId=line.PackageId,
                Status = line.Status,
                //Calls = line.Calls.Select(c => c.ToDto()).ToList(),
                //Client = line.Client.ToDto(),
                // SMS = line.SMS.Select(s => s.ToDto()).ToList()
            };
        }

        public static InvoiceServiceReference.LineDto ToDto1(this LineModel line)
        {
            if (line == null) return null;
            return new InvoiceServiceReference.LineDto()
            {
                ClientId = line.ClientId,
                LineId = line.LineId,
                Number = line.Number,
                PackageId = line.PackageId
                //Calls = line.Calls.Select(c => c.ToDto()).ToList(),
                //Client = line.Client.ToDto(),
                // SMS = line.SMS.Select(s => s.ToDto()).ToList()
            };
        }

        public static PackageModel ToModel(this CRMServiceReference.PackageDto package)
        {
            if (package == null) return null;
            return new PackageModel()
            {
                PackageId = package.PackageId,
                PackageName = package.PackageName,
                PackageTotalPrice = package.PackageTotalPrice,
                //PackageIncludes = package.PackageIncludes.Select(p => p.ToModel()).ToList()
                //Lines = package.Lines.Select(l => l.ToModel()).ToList(),
            };
        }

        public static PackageModel ToModel(this InvoiceServiceReference.PackageDto package)
        {
            if (package == null) return null;
            return new PackageModel()
            {
                PackageId = package.PackageId,
                PackageName = package.PackageName,
                PackageTotalPrice = package.PackageTotalPrice,
                //PackageIncludes = package.PackageIncludes.Select(p => p.ToModel()).ToList()
                //Lines = package.Lines.Select(l => l.ToModel()).ToList(),
            };
        }

        public static CRMServiceReference.PackageDto ToDto(this PackageModel package)
        {
            try
            {
                if (package == null) return null;
                return new CRMServiceReference.PackageDto()
                {
                    PackageId = package.PackageId,
                    PackageName = package.PackageName,
                    PackageTotalPrice = package.PackageTotalPrice,
                    //Lines = package.Lines.Select(p => p.ToDto()).ToList(),
                    //PackageIncludes = package.PackageIncludes.Select(p => p.ToDto()).ToList()
                };
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static PackageIncludesModel ToModel(this CRMServiceReference.PackageIncludesDto package)
        {
            if (package == null) return null;
            return new PackageIncludesModel()
            {
                DiscountPrecentage = package.DiscountPrecentage,
                FixedPrice = package.FixedPrice,
                Id = package.Id,
                IncludeName = package.IncludeName,
                InsideFamilyCalls = package.InsideFamilyCalls,
                MaxMinute = package.MaxMinute,
                MostCalledNumber = package.MostCalledNumber,
                //Package = package.Package.ToModel(),
                PackageId = package.PackageId,
                //Package = package.Package.ToModel()

            };
        }

        public static PackageIncludesModel ToModel(this InvoiceServiceReference.PackageIncludesDto package)
        {
            if (package == null) return null;
            return new PackageIncludesModel()
            {
                DiscountPrecentage = package.DiscountPrecentage,
                FixedPrice = package.FixedPrice,
                Id = package.Id,
                IncludeName = package.IncludeName,
                InsideFamilyCalls = package.InsideFamilyCalls,
                MaxMinute = package.MaxMinute,
                MostCalledNumber = package.MostCalledNumber,
                //Package = package.Package.ToModel(),
                PackageId = package.PackageId,
                //Package = package.Package.ToModel()

            };
        }

        public static CRMServiceReference.PackageIncludesDto ToDto(this PackageIncludesModel package)
        {
            try
            {
                if (package == null) return null;
                return new CRMServiceReference.PackageIncludesDto()
                {
                    DiscountPrecentage = package.DiscountPrecentage,
                    FixedPrice = package.FixedPrice,
                    Id = package.Id,
                    IncludeName = package.IncludeName,
                    InsideFamilyCalls = package.InsideFamilyCalls,
                    MaxMinute = package.MaxMinute,
                    MostCalledNumber = package.MostCalledNumber,
                    PackageId = package.PackageId,
                    //Package = package.Package.ToDto()
                    //Package = package.Package.ToDto(),
                    //SelectedNumber = package.SelectedNumber.ToDto(),
                    //Line=package.Line.ToDto(),
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static InvoiceServiceReference.PackageIncludesDto ToDto1(this PackageIncludesModel package)
        {
            try
            {
                if (package == null) return null;
                return new InvoiceServiceReference.PackageIncludesDto()
                {
                    DiscountPrecentage = package.DiscountPrecentage,
                    FixedPrice = package.FixedPrice,
                    Id = package.Id,
                    IncludeName = package.IncludeName,
                    InsideFamilyCalls = package.InsideFamilyCalls,
                    MaxMinute = package.MaxMinute,
                    MostCalledNumber = package.MostCalledNumber,
                    PackageId = package.PackageId,
                    //Package = package.Package.ToDto()
                    //Package = package.Package.ToDto(),
                    //SelectedNumber = package.SelectedNumber.ToDto(),
                    //Line=package.Line.ToDto(),
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        //public static PaymentModel ToModel(this PaymentDto payment)
        //{
        //    return new PaymentModel()
        //    {
        //        ClientId = payment.ClientId,
        //        Date = payment.Date,
        //        PaymentId = payment.PaymentId,
        //        TotalPayment = payment.TotalPayment,
        //        Client = payment.Client.ToModel()
        //    };
        //}

        //public static PaymentDto ToDto(this PaymentModel payment)
        //{
        //    return new PaymentDto()
        //    {
        //        ClientId = payment.ClientId,
        //        Date = payment.Date,
        //        PaymentId = payment.PaymentId,
        //        TotalPayment = payment.TotalPayment,
        //        Client = payment.Client.ToDto()
        //    };
        //}

        public static SelectedNumbersModel ToModel(this CRMServiceReference.SelectedNumbersDto numbers)
        {
            if (numbers == null) return null;
            return new SelectedNumbersModel()
            {
                FirstNumber = numbers.FirstNumber,
                Id = numbers.Id,
                SecondNumber = numbers.SecondNumber,
                ThirdNumber = numbers.ThirdNumber,
                //PackageIncludes = numbers.PackageIncludes.Select(p => p.ToModel()).ToList()
            };
        }

        public static CRMServiceReference.SelectedNumbersDto ToDto(this SelectedNumbersModel numbers)
        {
            if (numbers == null) return null;
            return new CRMServiceReference.SelectedNumbersDto()
            {
                FirstNumber = numbers.FirstNumber,
                Id = numbers.Id,
                SecondNumber = numbers.SecondNumber,
                ThirdNumber = numbers.ThirdNumber,
                //PackageIncludes = numbers.PackageIncludes.Select(p => p.ToDto()).ToList()
            };
        }

        //public static SMSModel ToModel(this SMSDto sms)
        //{
        //    return new SMSModel()
        //    {
        //        DestinationNumber = sms.DestinationNumber,
        //        ExternalPrice = sms.ExternalPrice,
        //        LineId = sms.LineId,
        //        SMSId = sms.SMSId,
        //        //Line = sms.Line.ToModel(),
        //        Time = sms.Time
        //    };
        //}

        //public static SMSDto ToDto(this SMSModel sms)
        //{
        //    return new SMSDto()
        //    {
        //        DestinationNumber = sms.DestinationNumber,
        //        ExternalPrice = sms.ExternalPrice,
        //        LineId = sms.LineId,
        //        SMSId = sms.SMSId,
        //        //Line = sms.Line.ToDto(),
        //        Time = sms.Time
        //    };
        //}

        public static SMSDto ToSms(CommunicationModel model)
        {
            if (model == null) return null;
            return new SMSDto()
            {
                DestinationNumber = model.DestinationNumber,
                ExternalPrice = model.ExternalPrice,
                LineId = model.LineId,
                Time = model.Time
            };
        }

        public static CallsDto ToCall(CommunicationModel model, double duration)
        {
            if (model == null) return null;
            return new CallsDto()
            {
                DestinationNumber = model.DestinationNumber,
                ExternalPrice = model.ExternalPrice,
                LineId = model.LineId,
                Time = model.Time,
                Duration = duration
            };
        }
    }
}