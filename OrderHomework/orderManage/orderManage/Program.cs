using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using orderManage;

namespace orderManage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My Store:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Commodity         Price");
            Console.WriteLine(" APPLE            7.2 ");
            Console.WriteLine(" BANANA           10 ");
            Console.WriteLine(" GRAPE            8.7 ");
            Console.WriteLine(" CHIP             6.3");
            Console.WriteLine(" TEA              3.5");
            Console.WriteLine(" COFFEE           26");
            Console.WriteLine(" IPHONE           12699 ");
            Console.WriteLine(" IPAD             10299");
            Console.WriteLine(" PERFUME          1099");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("How many orders do you want to make?");
            int orderAmount = int.Parse(Console.ReadLine());

            OrderService OrderService = new OrderService();

            try
            {
                //Print order
                for (int i = 0; i < orderAmount; i++)
                {
                    Console.WriteLine("Please enter the number " + (i + 1) + " customer's name.");
                    string client_name = Console.ReadLine();
                    Console.WriteLine("Please enter the number " + (i + 1) + " customer's address.");
                    string client_address = Console.ReadLine();
                    OrderService.AddOrder(client_name, client_address);


                    Console.WriteLine("Hi!" + client_name);
                    Console.WriteLine("How many kinds of commodities do you want to purchase?");
                    int kindAmount = int.Parse(Console.ReadLine());
                    for (int j = 0; j < kindAmount; j++)
                    {
                        Console.WriteLine("Please enter the number " + (j + 1) + " commodity's name.");
                        string itemName = Console.ReadLine();
                        Console.WriteLine("Please enetr the number " + (j + 1) + " commodity's amount.");
                        int itemAmount = int.Parse(Console.ReadLine());
                        switch (itemName)
                        {
                            case "APPLE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, itemAmount, 7.2);
                                }
                                break;
                            case "BANANA":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, itemAmount, 10);
                                }
                                break;
                            case "GRAPE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, itemAmount, 8.7);
                                }
                                break;
                            case "CHIP":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, itemAmount, 6.3);
                                }
                                break;
                            case "TEA":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, itemAmount, 3.5);
                                }
                                break;
                            case "COFFEE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, itemAmount,26);
                                }
                                break;
                            case "IPHONE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName,itemAmount,12699);
                                }
                                break;
                            case "IPAD":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, itemAmount, 10299);
                                }
                                break;
                            case "PERFUME":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName,itemAmount,1099);
                                }
                                break;
                            default:
                                {
                                    Console.WriteLine("We do not provide this commodity!");
                                    return;
                                }

                        }

                    }
                }

                OrderService.Export(OrderService.orderList);
                OrderService.Import("orders.xml");


                Console.WriteLine("----------------------------------------");
                OrderService.PrintOrders();

                //Index
                Console.WriteLine("Please enter the method number that you want to query.");
                Console.WriteLine("Enter '0': Choose to index by order name.");
                Console.WriteLine("Enter '1': Choose to index by order sumprice.");
                int indexMethod = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the client's name of the order.");
                string order_name = Console.ReadLine();
                var queryResults = OrderService.FindOrder(order_name, indexMethod);

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Here are the index results:");
                foreach (var queryResult in queryResults)
                {
                    Console.WriteLine(queryResult);
                }

                Console.WriteLine("----------------------------------------");
                Console.WriteLine();

                //Sort
                Console.WriteLine("Do you want to sort orders by order ID?");
                Console.WriteLine("If you want, please enter '1'.");
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Here are the sorted orders:");
                    OrderService.SortOrder(OrderService.orderList);
                    OrderService.PrintOrders();
                }


                //Delete
                Console.WriteLine("Delet orders.");
                Console.WriteLine("You can delet the order through entering order ID, please eneter the order ID");
                string IdForDelete = Console.ReadLine();
                OrderService.DeleteOrder(IdForDelete);
                OrderService.PrintOrders();

                //Alter
                Console.WriteLine("Change orders' information.");
                Console.WriteLine("You can change the order's information through entering order ID, please eneter the order ID");
                string IdForAlter = Console.ReadLine();
                Console.WriteLine("Please enter the name you want to change to:");
                string Alter_name = Console.ReadLine();
                Console.WriteLine("Please enter the order ID you want to change to:");
                string Alter_Id = Console.ReadLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Here are the altered orders:");
                OrderService.ChangeOrder(IdForAlter, Alter_name, Alter_Id);
                OrderService.PrintOrders();

            }
            catch (FormatException)
            {
                Console.WriteLine("Your input is wrong");
            }
            catch (InputErrorException e)
            {
                Console.WriteLine("The " + e.Description + "'s price or quantity can be a non positive number.");
            }
            catch (OrderItemRepeatException e)
            {
                Console.WriteLine("The " + e.Description + " has already existed in your order.");
            }
            catch (OrderRepeatException e)
            {
                Console.WriteLine("The order which id is " + e.Description + " has already existed.");
            }
            catch (OrderNotExistException e)
            {
                Console.WriteLine("Can't find the order that its information includes " + e.Description);
            }
        }
    }
}
