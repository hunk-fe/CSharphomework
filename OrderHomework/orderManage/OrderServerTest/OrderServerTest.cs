using System;
using orderManage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace OrderServerTest
{
    [TestClass]
    public class OrderServerTest
    {
        OrderService orderServiceTest = new OrderService();

        [TestMethod]
        public void AddOrderTest()
        {
            
            Assert.IsTrue(orderServiceTest.AddOrder(1,"Tom", "china"));
        }

        [TestMethod]
        [ExpectedException(typeof(OrderRepeatException))]
        public void AddOrderTest2()
        {
            orderServiceTest.AddOrder(1,"Tom", "china");
            orderServiceTest.AddOrder(1,"Tom", "china");
        }

        [TestMethod]
        public void FindIndexByNameTest()
        {
            orderServiceTest.AddOrder(1,"Jony", "china");
            orderServiceTest.AddOrder(2,"Tom", "china");
            Assert.IsNotNull(orderServiceTest.FindIndexByName("Tom"));
        }

        [TestMethod]
        [ExpectedException(typeof(OrderNotExistException))]
        public void FindIndexByNameTest2()
        {
            orderServiceTest.FindIndexByName("Tom");
        }

        [TestMethod]
        public void DeleteOrderTest()
        {
            orderServiceTest.AddOrder(1,"Jony", "china");
            Assert.IsTrue(orderServiceTest.DeleteOrder("Jony"));
        }

        [TestMethod]
        public void ChangeOrderTest()
        {
            orderServiceTest.AddOrder(1,"Jony", "china");
            orderServiceTest.AddOrder(2,"Tom", "china");
            orderServiceTest.ChangeOrder("Tom", "Hery", "china");
            Assert.IsNotNull(orderServiceTest.FindIndexByName("Hery"));
        }

        [TestMethod]
        public void FindOrderTest()
        {
            orderServiceTest.AddOrder(1,"Jony", "china");
            orderServiceTest.AddOrder(2,"Tom", "china");
            Assert.IsNotNull(orderServiceTest.FindOrder("Tom",1));
        }

        [TestMethod]
        [ExpectedException(typeof(OrderNotExistException))]
        public void FindOrder()
        {
            orderServiceTest.AddOrder(1,"Jony", "china");
            orderServiceTest.FindOrder("Jan", 0);
        }

        [TestMethod]
        public void ExportTest()
        {
            orderServiceTest.AddOrder(1,"Jony", "china");
            orderServiceTest.AddOrder(2,"Tom", "china");
            orderServiceTest.Export(orderServiceTest.orderList);
            Assert.IsNotNull("orders.xml");
        }


        [TestMethod]
        public void ImportTest()
        {
            orderServiceTest.AddOrder(1,"Jony", "china");
            orderServiceTest.AddOrder(2,"Tom", "china");
            orderServiceTest.Export(orderServiceTest.orderList);
            orderServiceTest.Import("orders.xml");
            Assert.IsNotNull(orderServiceTest.FindIndexByName("Tom"));
        }

        [TestMethod]
        public void SortOrderTest()
        {
            Order order2 = new Order(2,"Jony", "china");
            Order order3 = new Order(3,"Tom", "china");
            Order order1 = new Order(1,"Hery", "china");

            orderServiceTest.orderList.Add(order2);
            orderServiceTest.orderList.Add(order3);
            orderServiceTest.orderList.Add(order1);

            order2.orderNum = 2;
            order3.orderNum = 3;
            order1.orderNum = 1;

            orderServiceTest.SortOrder(orderServiceTest.orderList);
            List<Order> orderListTest = new List<Order> { new Order(1,"Hery","china"), new Order(2,"Jony","china"),
            new Order(3,"Tom","china")};

            CollectionAssert.AreEqual(orderListTest, orderServiceTest.orderList);
        }
    }
}
