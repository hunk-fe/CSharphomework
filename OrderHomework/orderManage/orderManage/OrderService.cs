﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using orderManage;
using System.IO;
using System.Xml.Serialization;

namespace orderManage
{
    public class OrderService
    {
        public List<Order> orderList = new List<Order>();
        int orderAmount = 0;

        public bool AddOrder(string client, string address)
        {
            Order order = new Order(client, address);
            bool isRepeat = false;
            foreach (Order od in orderList)
            {
                if (od.Equals(order))
                {
                    isRepeat = true;
                }
                else
                {
                    isRepeat = false;
                }
            }
            if (!isRepeat)
            {
                orderList.Add(order);
                orderAmount++;
                return true;
            }
            else
            {
                throw new OrderRepeatException(client);
            }

        }

        //Index by Name, this function is used in DeleteOrder()
        public int FindIndexByName(string client)
        {
            int i = 0;
            foreach (Order order in orderList)
            {
                if (order.client == client)
                    return i;
                i++;
            }
            throw new OrderNotExistException(client);
        }

        public bool DeleteOrder(string client)
        {
            int index = FindIndexByName(client);
            orderList.RemoveAt(index);
            orderAmount--;
            return true;
        }

        public void ChangeOrder(string client, string after_name, string after_address)
        {
            int index = FindIndexByName(client);
            orderList[index].client = after_name;
            orderList[index].address = after_address;

        }

        enum IndexMethod
        {
            IndexByOrderName = 0,
            IndexByOrderSumPrice = 1
        }

        public IEnumerable<Order> FindOrder(string inputString, int flag)
        {
            switch ((IndexMethod)flag)
            {
                case IndexMethod.IndexByOrderName:
                    {
                        var query = from order in orderList
                                    where order.client == inputString
                                    orderby order.client
                                    select order;
                        if (query.Count() > 0)
                        {
                            return query;
                        }
                        else
                        {
                            throw new OrderNotExistException(inputString);
                        }
                    }
                case IndexMethod.IndexByOrderSumPrice:
                    {
                        var query = from order in orderList
                                    where order.client == inputString
                                    orderby order.sumPrice
                                    select order;
                        if (query.Count() > 0)
                        {
                            return query;
                        }
                        else
                        {
                            throw new OrderNotExistException(inputString);
                        }
                    }
                default:
                    return null;
            }
        }
        
        public void Export(List<Order> orders)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream("orders.xml", FileMode.Create)) {
                xmlSerializer.Serialize(fs, orders);
            }

            Console.WriteLine("\nSerialized as XML:");
            Console.WriteLine(File.ReadAllText("orders.xml"));
        }

        public void Import(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                List<Order> orders = new List<Order>();
                orders = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }

        public void SortOrder(List<Order> orders)
        {
            orders.Sort((order1, order2) => order1.orderNum.CompareTo(order2.orderNum));
        }

        public void PrintOrders()
        {
            Console.WriteLine("Your order:");
            for (int i = 0; i < orderAmount; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Order" + (i + 1) + ":");
                Console.Write(orderList[i]);
                Console.WriteLine(" ");
            }
        }
    }
}