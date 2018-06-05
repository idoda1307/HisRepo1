using System;
using Common.Interfaces.RepositoryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using Common.Models;
using DAL.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class RepositoriesUnitTest
    {
        private IClientRepository clientRepository;

        public RepositoriesUnitTest()
        {
            clientRepository = new ClientRepository();
        }
        //[TestMethod]
        //public void Client_UnitTest()
        //{
        //    ClientDto client = new ClientDto()
        //    {
        //        Address="jij",
        //        ClientTypeId=1,
        //        ContactNumber="uhijikl",
        //        FirstName="yuhijji",
        //        LastName="hujklkl"
        //    };
        //    ClientDto dto=clientRepository.CreateClient(client).Result;
        //    Assert.AreEqual(dto, client);
        //}

        [TestMethod]
        public void ADD_CLIENT_WITH_LINES()
        {
            var clients = clientRepository.GetClients();

            var client = clientRepository.GetClient("1");

            client.Lines = new List<LineDto>();
            //client.Lines.Add(new LineDto
            //{
            //    ClientId = "1",
            //    Number = "123aniyodea",
            //    PackageId = 1,
            //    Status = LineStatus.available
            //});

            //var something = 
            //Console.WriteLine(something.Result);

            client = clientRepository.GetClient("1");
            var line = client.Lines.FirstOrDefault(l => l.Number == "123aniyodea");


            Assert.IsTrue(line != null);
        }
    }
}
