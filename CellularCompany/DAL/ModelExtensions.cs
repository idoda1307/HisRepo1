using DAL.Models;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Dtos
{
    public static class ModelExtensions
    {
        public static CallsEntity ToModel(this CallsDto call)
        {
            if (call == null) return null;
            return new CallsEntity()
            {
                CallId = call.CallId,
                DestinationNumber = call.DestinationNumber,
                Duration = call.Duration,
                ExternalPrice = call.ExternalPrice,
                LineId = call.LineId,
                Line = call.Line.ToModel(),
                Time = call.Time
            };
        }

        public static CallsDto ToDto(this CallsEntity call)
        {
            if (call == null) return null;
            return new CallsDto()
            {
                CallId = call.CallId,
                DestinationNumber = call.DestinationNumber,
                Duration = call.Duration,
                ExternalPrice = call.ExternalPrice,
                LineId = call.LineId,
                //Line = call.Line.ToDto(),
                Time = call.Time
            };
        }

        public static ClientEntity ToModel(this ClientDto client)
        {
            if (client == null) return null;
            try
            {
                return new ClientEntity()
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static ClientDto ToDto(this ClientEntity client)
        {
            if (client == null) return null;
            return new ClientDto()
            {
                Address = client.Address,
                ClientId = client.ClientId,
                ClientTypeId = client.ClientTypeId,
                ContactNumber = client.ContactNumber,
                FirstName = client.FirstName,
                LastName = client.LastName,
                ClientType = client.ClientType.ToDto(),
                CallsToCenter = client.CallsToCenter
                //Lines=client.Lines.ToList().Select(l=>l.ToDto()).ToList(),
                //Payments=client.Payments.Select(p => p.ToDto()).ToList()
            };
        }

        public static ClientTypeEntity ToModel(this ClientTypeDto clientType)
        {
            if (clientType == null) return null;
            return new ClientTypeEntity()
            {
                ClientTypeId = clientType.ClientTypeId,
                MinutePrice = clientType.MinutePrice,
                SMSPrice = clientType.SMSPrice,
                TypeName = clientType.TypeName,
                //Clients = clientType.Clients.Select(c => c.ToModel()).ToList()
            };
        }

        public static ClientTypeDto ToDto(this ClientTypeEntity clientType)
        {
            if (clientType == null) return null;
            return new ClientTypeDto()
            {
                ClientTypeId = clientType.ClientTypeId,
                MinutePrice = clientType.MinutePrice,
                SMSPrice = clientType.SMSPrice,
                TypeName = clientType.TypeName
                //Clients=clientType.Clients.Select(c=>c.ToDto()).ToList()
            };
        }

        public static LineEntity ToModel(this LineDto line)
        {
            if (line == null) return null;
            return new LineEntity()
            {
                ClientId = line.ClientId,
                LineId = line.LineId,
                Number = line.Number,
                Status = line.Status,
                PackageId=line.PackageId,
                SelectedNumber=line.SelectedNumber.ToModel()
                //Calls=line.Calls.Select(c=>c.ToModel()).ToList(),
                //Client = line.Client.ToModel(),
                //Package=line.Package.ToModel(),
                //Package = line.Package.ToModel(),
                //SMS=line.SMS.Select(s=>s.ToModel()).ToList()
            };
        }

        public static LineDto ToDto(this LineEntity line)
        {
            if (line == null) return null;
            return new LineDto()
            {
                ClientId = line.ClientId,
                LineId = line.LineId,
                Number = line.Number,
                Status = line.Status,
                PackageId =line.PackageId
            };
        }

        public static PackageEntity ToModel(this PackageDto package)
        {
            if (package == null) return null;
            return new PackageEntity()
            {
                PackageId = package.PackageId,
                PackageName = package.PackageName,
                PackageTotalPrice = package.PackageTotalPrice,
                //Lines=package.Lines.Select(l=>l.ToModel()).ToList()
            };
        }

        public static PackageDto ToDto(this PackageEntity package)
        {
            if (package == null) return null;
            return new PackageDto()
            {
                PackageId = package.PackageId,
                PackageName = package.PackageName,
                PackageTotalPrice = package.PackageTotalPrice,
                //Lines=package.Lines.Select(p=>p.ToDto()).ToList()
            };
        }

        public static PackageIncludesEntity ToModel(this PackageIncludesDto package)
        {
            if (package == null) return null;
            return new PackageIncludesEntity()
            {
                DiscountPrecentage = package.DiscountPrecentage,
                FixedPrice = package.FixedPrice,
                PackageIncludesId = package.Id,
                IncludeName = package.IncludeName,
                InsideFamilyCalls = package.InsideFamilyCalls,
                MaxMinute = package.MaxMinute,
                MostCalledNumber = package.MostCalledNumber,
                //Package=package.Package.ToModel(),
                //Package = package.Package.ToModel(),
                //Line=package.Line.ToModel(),
            };
        }

        public static PackageIncludesDto ToDto(this PackageIncludesEntity package)
        {
            if (package == null) return null;
            return new PackageIncludesDto()
            {
                DiscountPrecentage = package.DiscountPrecentage,
                FixedPrice = package.FixedPrice,
                Id = package.PackageIncludesId,
                IncludeName = package.IncludeName,
                InsideFamilyCalls = package.InsideFamilyCalls,
                MaxMinute = package.MaxMinute,
                MostCalledNumber = package.MostCalledNumber,
                //Package=package.Package.ToDto(),
                //Package=package.Package.ToDto()
            };
        }

        public static PaymentEntity ToModel(this PaymentDto payment)
        {
            if (payment == null) return null;
            return new PaymentEntity()
            {
                ClientId = payment.ClientId,
                Date = payment.Date,
                PaymentId = payment.PaymentId,
                TotalPayment = payment.TotalPayment,
                Client = payment.Client.ToModel()
            };
        }

        public static PaymentDto ToDto(this PaymentEntity payment)
        {
            if (payment == null) return null;
            return new PaymentDto()
            {
                ClientId = payment.ClientId,
                Date = payment.Date,
                PaymentId = payment.PaymentId,
                TotalPayment = payment.TotalPayment,
                Client = payment.Client.ToDto()
            };
        }

        public static SelectedNumbersEntity ToModel(this SelectedNumbersDto numbers)
        {
            if (numbers == null) return null;
            return new SelectedNumbersEntity()
            {
                FirstNumber = numbers.FirstNumber,
                Id = numbers.Id,
                SecondNumber = numbers.SecondNumber,
                ThirdNumber = numbers.ThirdNumber
                //PackageIncludes=numbers.PackageIncludes.ToModel()
            };
        }

        public static SelectedNumbersDto ToDto(this SelectedNumbersEntity numbers)
        {
            if (numbers == null) return null;
            return new SelectedNumbersDto()
            {
                FirstNumber = numbers.FirstNumber,
                Id = numbers.Id,
                SecondNumber = numbers.SecondNumber,
                ThirdNumber = numbers.ThirdNumber,
                LineId=numbers.Line.LineId
                //PackageIncludes=numbers.PackageIncludes.Select(p=>p.ToDto()).ToList()
            };
        }

        public static SMSEntity ToModel(this SMSDto sms)
        {
            if (sms == null) return null;
            return new SMSEntity()
            {
                DestinationNumber = sms.DestinationNumber,
                ExternalPrice = sms.ExternalPrice,
                LineId = sms.LineId,
                SMSId = sms.SMSId,
                Line = sms.Line.ToModel(),
                Time = sms.Time
            };
        }

        public static SMSDto ToDto(this SMSEntity sms)
        {
            if (sms == null) return null;
            return new SMSDto()
            {
                DestinationNumber = sms.DestinationNumber,
                ExternalPrice = sms.ExternalPrice,
                LineId = sms.LineId,
                SMSId = sms.SMSId,
                Line = sms.Line.ToDto(),
                Time = sms.Time
            };
        }
    }
}