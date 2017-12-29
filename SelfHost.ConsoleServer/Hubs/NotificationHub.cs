using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfHost.ConsoleServer.Hubs
{
    public class Product
    {
        public Product(int productId, string productName, double price)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
        }
        public int ProductId { get; }
        public string ProductName { get; }
        public double Price { get; }
    }


    public class NotificationHub : Hub
    {

        public ObservableCollection<Product> GetAllProducts()
        {

            var product = new ObservableCollection<Product>
            {
                new Product(1,"Elma",30.22),
                new Product(2,"Mango",20.22),
                new Product(3,"Muz",10.12),
                new Product(4,"Karpuz",30.22),
            };
            return product;

        }

        public void ServerTime()
        {
            //do
            //{
            Console.WriteLine($"Bağlanıldı {Context.ConnectionId} Time: {DateTime.Now:T}");
            Clients.All.displayTime($"{DateTime.Now:T}");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            //} while (true);

            //}
        }
    }
}
