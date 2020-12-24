using System;
using System.Linq;
using Sprint_16.Models;

namespace Sprint_16.Service
{
    public class SampleDataService
    { 
        public static void SeedData(ShoppingContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange
                (
                    new Customer
                    {
                        FirstName = "Zosya",
                        LastName = "Sinitsina",
                        Address = "Lviv",
                        Discount = 10
                    },
                    new Customer
                    {
                        FirstName = "Vadym",
                        LastName = "Nesterenko",
                        Address = "Odessa",
                        Discount = 5
                    },
                    new Customer
                    {
                        FirstName = "Vasyl",
                        LastName = "Kurtyanyk",
                        Address = "Lviv",
                        Discount = 0
                    },
                    new Customer
                    {
                        FirstName = "Vadym",
                        LastName = "Pyshnyak",
                        Address = "Ternopil",
                        Discount = 0
                    },
                    new Customer
                    {
                        FirstName = "Lesya",
                        LastName = "Zenevych",
                        Address = "Kyiv",
                        Discount = 0
                    },
                    new Customer
                    {
                        FirstName = "Adam",
                        LastName = "Kozlevych",
                        Address = "Rio de Zhmerinka",
                        Discount = 3
                    },
                    new Customer
                    {
                        FirstName = "Ostap",
                        LastName = "Semenov",
                        Address = "Dnipro",
                        Discount = 5
                    }
                );

                context.SaveChanges();
            }

            if(!context.SuperMarkets.Any())
            {
                context.SuperMarkets.AddRange
                (
                    new SuperMarket
                    {
                        Name = "Metro",
                        Address = "Lviv, Horodotska"
                    },
                    new SuperMarket
                    {
                        Name = "ATB-Market",
                        Address = "Lviv, G. Washington"
                    },
                    new SuperMarket
                    {
                        Name = "Billa",
                        Address = "Odessa"
                    },
                    new SuperMarket
                    {
                        Name = "Big Pocket",
                        Address = "Lviv"
                    },
                    new SuperMarket
                    {
                        Name = "Wellmart",
                        Address = "Chernivtsi, Rus'ka"
                    }
                );

                context.SaveChanges();
            }

            if(!context.Products.Any())
            {
                context.Products.AddRange
                (
                    new Product
                    {
                        Name = "Banana",
                        Price = 21
                    },
                    new Product
                    {
                        Name = "Cola",
                        Price = 20
                    },
                    new Product
                    {
                        Name = "Sausage",
                        Price = 40
                    },
                    new Product
                    {
                        Name = "Milk",
                        Price = 25
                    },
                    new Product
                    {
                        Name = "Cucumber",
                        Price = 35
                    },
                    new Product
                    {
                        Name = "Beer",
                        Price = 31
                    },
                    new Product
                    {
                        Name = "Pink salmon",
                        Price = 112
                    },
                    new Product
                    {
                        Name = "Ice cream",
                        Price = 21
                    },
                    new Product
                    {
                        Name = "Cheese",
                        Price = 150
                    }
                );

                context.SaveChanges();
            }

            if(!context.Orders.Any())
            {
                context.Orders.AddRange
                (
                    new Order
                    {
                        OrderDate = new DateTime(2020, 12, 22),
                        CustomerId = 1,
                        SuperMarketId = 1
                    },
                    new Order
                    {
                        OrderDate = new DateTime(2020, 12, 21),
                        CustomerId = 2,
                        SuperMarketId = 2
                    },
                    new Order
                    {
                        OrderDate = new DateTime(2020, 12, 20),
                        CustomerId = 3,
                        SuperMarketId = 3
                    },
                    new Order
                    {
                        OrderDate = new DateTime(2020, 12, 20),
                        CustomerId = 4,
                        SuperMarketId = 4
                    }
                );

                context.SaveChanges();
            }

            if(!context.OrderDetails.Any())
            {
                context.OrderDetails.AddRange
                (
                    new OrderDetail
                    {
                        OrderId = 1,
                        ProductId = 1,
                        Quantity = 1
                    },
                    new OrderDetail
                    {
                        OrderId = 1,
                        ProductId = 2,
                        Quantity = 2
                    },
                    new OrderDetail
                    {
                        OrderId = 1,
                        ProductId = 3,
                        Quantity = 1
                    },
                    new OrderDetail
                    {
                        OrderId = 2,
                        ProductId = 6,
                        Quantity = 3
                    },
                    new OrderDetail
                    {
                        OrderId = 2,
                        ProductId = 5,
                        Quantity = 2
                    },
                    new OrderDetail
                    {
                        OrderId = 2,
                        ProductId = 1,
                        Quantity = 10
                    },
                    new OrderDetail
                    {
                        OrderId = 3,
                        ProductId = 7,
                        Quantity = 2
                    },
                    new OrderDetail
                    {
                        OrderId = 3,
                        ProductId = 2,
                        Quantity = 4
                    },
                    new OrderDetail
                    {
                        OrderId = 3,
                        ProductId = 1,
                        Quantity = 3
                    },
                    new OrderDetail
                    {
                        OrderId = 3,
                        ProductId = 2,
                        Quantity = 2
                    },
                    new OrderDetail
                    {
                        OrderId = 3,
                        ProductId = 3,
                        Quantity = 6
                    },
                    new OrderDetail
                    {
                        OrderId = 3,
                        ProductId = 5,
                        Quantity = 2
                    },
                    new OrderDetail
                    {
                        OrderId = 4,
                        ProductId = 9,
                        Quantity = 2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
