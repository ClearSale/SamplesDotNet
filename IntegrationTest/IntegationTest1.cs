using ClearSaleModel;
using ClearSaleModel.Request;
using ClearSaleModel.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace IntegrationTest
{

    [TestClass]
    public class IntegationTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            RequestAuth request = new RequestAuth();
            request.Login = new Credentials() { 
            ApiKey = ConfigurationManager.AppSettings["ApiKey"],
            ClientID = ConfigurationManager.AppSettings["ClientID"],
            ClientSecret = ConfigurationManager.AppSettings["ClientSecret"]
            };

            ResponseAuth response = this.Login(request);

            Assert.IsNotNull(response.Token);
        }

        [TestMethod]
        public void LogoutTest()
        {
            RequestAuth request = new RequestAuth();
            request.Login = new Credentials()
            {
                ApiKey = ConfigurationManager.AppSettings["ApiKey"],
                ClientID = ConfigurationManager.AppSettings["ClientID"],
                ClientSecret = ConfigurationManager.AppSettings["ClientSecret"]
            };

            bool response = this.Logout(request);

            Assert.IsTrue(response);
        }

        [TestMethod]
        public void SendTest()
        {

            RequestAuth requestAuth = new RequestAuth();
            requestAuth.Login = new Credentials()
            {
                ApiKey = ConfigurationManager.AppSettings["ApiKey"],
                ClientID = ConfigurationManager.AppSettings["ClientID"],
                ClientSecret = ConfigurationManager.AppSettings["ClientSecret"]
            };

            ResponseAuth responseAuth = this.Login(requestAuth);

            RequestSend request = new RequestSend();
            ResponseSend response = new ResponseSend();

            request.ApiKey = ConfigurationManager.AppSettings["ApiKey"];
            request.LoginToken = responseAuth.Token.Value;
            request.AnalysisLocation = ConfigurationManager.AppSettings["AnalysisLocation"];

            request.Orders = new List<Order>();
            request.Orders.Add(CreateOrder());

            response = this.SendOrders(request);

            Assert.IsNotNull(response.Orders[0]);
        }


        [TestMethod]
        public void GetTest()
        {

            RequestAuth requestAuth = new RequestAuth();
            requestAuth.Login = new Credentials()
            {
                ApiKey = ConfigurationManager.AppSettings["ApiKey"],
                ClientID = ConfigurationManager.AppSettings["ClientID"],
                ClientSecret = ConfigurationManager.AppSettings["ClientSecret"]
            };

            ResponseAuth responseAuth = this.Login(requestAuth);


            RequestGet request = new RequestGet();
            ResponseGet response = new ResponseGet();

            request.AnalysisLocation = ConfigurationManager.AppSettings["AnalysisLocation"];
            request.ApiKey = ConfigurationManager.AppSettings["ApiKey"];
            request.LoginToken = responseAuth.Token.Value;
            request.Orders = new List<string>(){
                "ORDER_ID"
            };

            response = this.GetOrders(request);

            Assert.AreEqual(response.Orders[0].ID, "ORDER_ID");
        }

        private ResponseAuth Login(RequestAuth credentials)
        {
            ResponseAuth authToken = new ResponseAuth();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);

                StringContent data = new StringContent(JsonConvert.SerializeObject(credentials).ToString(), Encoding.UTF8, "application/json");

                string json = client.PostAsync("/api/auth/login", data).Result.Content.ReadAsStringAsync().Result;

                authToken = JsonConvert.DeserializeObject<ResponseAuth>(json);
            }
            
            return authToken;
                
        }


        private bool Logout(RequestAuth credentials)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);

                StringContent data = new StringContent(JsonConvert.SerializeObject(credentials).ToString(), Encoding.UTF8, "application/json");

                string json = client.PostAsync("/api/auth/logout", data).Result.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(json))
                {
                    return false;
                }

                return true;
            }
        }


        private ResponseSend SendOrders(RequestSend order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);

                StringContent data = new StringContent(JsonConvert.SerializeObject(order).ToString(), Encoding.UTF8, "application/json");

                string json = client.PostAsync("/api/order/send", data).Result.Content.ReadAsStringAsync().Result;
                ResponseSend response = JsonConvert.DeserializeObject<ResponseSend>(json);
                
                return response;
            }
        }


        private ResponseGet GetOrders(RequestGet order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);

                StringContent data = new StringContent(JsonConvert.SerializeObject(order).ToString(), Encoding.UTF8, "application/json");

                string json = client.PostAsync("/api/order/get", data).Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ResponseGet>(json);
            }
        }

        private Order CreateOrder()
        {
            Order order = new Order();
            order.ID = "ORDER_ID";
            order.Email = "john.smith@email.com";
            order.Date = DateTime.Now;
            order.TotalOrder = 100m;
            order.TotalItems = 90m;
            order.TotalShipping = 10;
            order.SessionID = Guid.NewGuid().ToString();
            order.Reanalysis = false;
            order.IP = "192.168.0.1";
            order.Currency = "USD";
            order.ShippingData = GetPerson();
            order.BillingData = GetPerson();
            order.Payments = new List<Payment>();
            order.Payments.Add(new Payment()
            {
                Date = DateTime.Now,
                Amount = 100.00m,
                CardBin = "411111",
                CardEndNumber = "1111",
                CardHolderName = "John Smith",
                Type = 1,
                CardType = 1
            });
            order.Items = new List<Item>();
            order.Items.Add(new Item() {
            Price = 45.00m,
            Quantity = 2,
            ProductTitle = "Pants",
            });
            order.CustomFields = new List<Custom>();
            order.CustomFields.Add(new Custom() 
            {
                Name = "AVS_RESPONSE",
                Type = 1,
                Value = "Y"
            });
            order.CustomFields.Add(new Custom()
            {
                Name = "CVV_RESULT_CODE",
                Type = 1,
                Value = "Y"
            });

            return order;
        }

        private Person GetPerson()
        {
            Person person = new Person();
            person.Name = "John Smith";
            person.ID = "1";
            person.Type = 1;
            person.Gender = 'M';
            person.BirthDate = new DateTime(1986, 5, 27); // if don't have a birth date,please to send the DateTime.Now
            person.Address = new Address();
            person.Address.AddressLine1 = "7300 Biscayne Blvd";
            person.Address.AddressLine2 = "Suite 200";
            person.Address.City = "Miami";
            person.Address.State = "FL";
            person.Address.ZipCode = "33131";
            person.Address.Country = "United States";
            person.Phones = new List<Phone>();
            person.Phones.Add(new Phone() {
            CountryCode = "+1",
            AreaCode="786",
            Number = "7868884584"
            });

            return person;
        }
    }

}
