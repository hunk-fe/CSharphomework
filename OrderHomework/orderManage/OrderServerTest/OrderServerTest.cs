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
            
            Assert.IsTrue(orderServiceTest.AddOrder("Tom", "china"));
        }

        [TestMethod]
        [ExpectedException(typeof(OrderRepeatException))]
        public void AddOrderTest2()
        {
            orderServiceTest.AddOrder("Tom", "china");
            orderServiceTest.AddOrder("Tom", "china");
        }

        [TestMethod]
        public void FindIndexByNameTest()
        {
            orderServiceTest.AddOrder("Jony", "china");
            orderServiceTest.AddOrder("Tom", "china");
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
            orderServiceTest.AddOrder("Jony", "china");
            Assert.IsTrue(orderServiceTest.DeleteOrder("Jony"));
        }

        [TestMethod]
        public void ChangeOrderTest()
        {
            orderServiceTest.AddOrder("Jony", "china");
            orderServiceTest.AddOrder("Tom", "china");
            orderServiceTest.ChangeOrder("Tom", "Hery", "china");
            Assert.IsNotNull(orderServiceTest.FindIndexByName("Hery"));
        }

        [TestMethod]
        public void FindOrderTest()
        {
            orderServiceTest.AddOrder("Jony", "china");
            orderServiceTest.AddOrder("Tom", "china");
            Assert.IsNotNull(orderServiceTest.FindOrder("Tom",1));
        }

        [TestMethod]
        [ExpectedException(typeof(OrderNotExistException))]
        public void FindOrder()
        {
            orderServiceTest.AddOrder("Jony", "china");
            orderServiceTest.FindOrder("Jan", 0);
        }

        [TestMethod]
        public void ExportTest()
        {
            orderServiceTest.AddOrder("Jony", "china");
            orderServiceTest.AddOrder("Tom", "china");
            orderServiceTest.Export(orderServiceTest.orderList);
            Assert.IsNotNull("orders.xml");
        }


        [TestMethod]
        public void ImportTest()
        {
            orderServiceTest.AddOrder("Jony", "china");
            orderServiceTest.AddOrder("Tom", "china");
            orderServiceTest.Export(orderServiceTest.orderList);
            orderServiceTest.Import("orders.xml");
            Assert.IsNotNull(orderServiceTest.FindIndexByName("Tom"));
        }

        [TestMethod]
        public void SortOrderTest()
        {
            Order order2 = new Order("Jony", "china");
            Order order3 = new Order("Tom", "china");
            Order order1 = new Order("Hery", "china");

            orderServiceTest.orderList.Add(order2);
            orderServiceTest.orderList.Add(order3);
            orderServiceTest.orderList.Add(order1);

            order2.orderNum = 2;
            order3.orderNum = 3;
            order1.orderNum = 1;

            orderServiceTest.SortOrder(orderServiceTest.orderList);
            List<Order> orderListTest = new List<Order> { new Order("Hery","china"), new Order("Jony","china"),
            new Order("Tom","china")};

            CollectionAssert.AreEqual(orderListTest, orderServiceTest.orderList);
        }
    }
}
