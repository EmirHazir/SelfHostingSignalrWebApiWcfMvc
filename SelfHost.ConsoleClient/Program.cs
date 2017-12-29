using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost.ConsoleClient
{
    public class ProductView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        static void RunSignalrClient()
        {
            HubConnection connection = new HubConnection("http://localhost:8389");
            var proxy = connection.CreateHubProxy("notificationHub");
            try
            {
                connection.Start().Wait();
                proxy.On<string>("displayTime", time =>
                {
                    Console.Clear();
                    Console.WriteLine(time);
                });
                proxy.Invoke("ServerTime");
                var products= proxy.Invoke<ObservableCollection<ProductView>>("GetAllProducts").Result;
                products.ToList()?.ForEach(p => Console.WriteLine($"Product: { p.ProductName + " " + p.Price}"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        //static string[] RunWebApi()
        //{
        //    HttpClient client = new HttpClient();
        //    var message = client.GetAsync("http://localhost:8389/api/product").Result;
        //    var result = message.Content.ReadAsStringAsync().Result;
        //    //if (message.IsSuccessStatusCode)
        //    ////{
        //    ////    return result;
        //    ////}
        //    return null;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Signalr başlatmak için enter tuşuna basınız");
            Console.ReadLine();
            RunSignalrClient();
            Console.ReadLine();
        }
    }
}
