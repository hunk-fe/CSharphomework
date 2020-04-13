using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using orderManage;

namespace WinForm
{
    public partial class Form3 : Form
    {

        // 定义委托
        // public delegate void DataChangeHandler(string x); 一次可以传递一个string
        public delegate void UpdateOrderHandler(object sender, UpdateOrderEventArgs args);
        // 声明事件
        public event UpdateOrderHandler UpdateOrder;
        public List<Order> ords;
        // 调用事件函数

        public void OnDataChange(object sender, UpdateOrderEventArgs args)
        {
            if (UpdateOrder != null)
            {
                UpdateOrder(this, args);
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(List<Order> orders)
        {
            InitializeComponent();
            List<int> UpdateId = new List<int>();
            ords = orders;
            foreach (var a in ords)
            {
                UpdateId.Add(a.orderNum);
            }
            ordersComboBox.DataSource = UpdateId;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int UpdateOrderNum = Convert.ToInt32(ordersComboBox.SelectedItem);
            OnDataChange(this, new UpdateOrderEventArgs(UpdateOrderNum, clientText.Text, addressText.Text, appleNum.Text, bananaNum.Text, grapeNum.Text, chipNum.Text, teaNum.Text, ipadNum.Text, iphoneNum.Text, coffeeNum.Text, perfumeNum.Text));

            this.Close();
        }

        private void ordersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ordersComboBox.Text);
            Order ord = ords.Where(o => o.orderNum == id).FirstOrDefault();
            clientText.Text = ord.client;
            addressText.Text = ord.address;
            appleNum.Text = "";
            bananaNum.Text = "";
            grapeNum.Text = "";
            chipNum.Text = "";
            teaNum.Text = "";
            ipadNum.Text = "";
            iphoneNum.Text = "";
            coffeeNum.Text = "";
            perfumeNum.Text = "";
            List<OrderItem> items = ord.orderItemList;
            foreach (var a in items)
            {
                if (a.tradeName == "APPLE") { appleNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "BANANA") { bananaNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "GRAPE") { grapeNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "CHIP") { chipNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "TEA") { teaNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "IPAD") { ipadNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "IPHONE") { iphoneNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "COFFEE") { coffeeNum.Text = Convert.ToString(a.tradeNum); }
                if (a.tradeName == "PERFUME") { perfumeNum.Text = Convert.ToString(a.tradeNum); }
            }
        }
    }
    public class UpdateOrderEventArgs : EventArgs

    {

        public int orderNum { get; set; }

        public string client { get; set; }

        public string address { get; set; }

        //public List<OrderItem> items = new List<OrderItem>();
        public List<OrderItem> Items { get; set; }
        public UpdateOrderEventArgs(int OrderNum, string Client, string Address, string AppleNum, string BananaNum, string GrapeNum, string ChipNum, string TeaNum, string IpadNum, string IphoneNum, string CoffeeNum, string PerfumeNum)

        {

            orderNum = OrderNum;

            client = Client;
            address = Address;

            List<OrderItem> items = new List<OrderItem>();

            if (!(AppleNum == "" || AppleNum == null || AppleNum == "0"))
            {
                OrderItem apple = new OrderItem("APPLE", Int32.Parse(AppleNum), 7.2);
                items.Add(apple);
            }
            if (!(BananaNum == "" || BananaNum == null || BananaNum == "0"))
            {
                OrderItem banana = new OrderItem("BANANA", Int32.Parse(BananaNum), 10);
                items.Add(banana);
            }
            if (!(GrapeNum == "" || GrapeNum == null || GrapeNum == "0"))
            {
                OrderItem grape = new OrderItem("GRAPE", Int32.Parse(GrapeNum), 8.7);
                items.Add(grape);
            }
            if (!(ChipNum == "" || ChipNum == null || ChipNum == "0"))
            {
                OrderItem chip = new OrderItem("CHIP", Int32.Parse(ChipNum), 6.3);
                items.Add(chip);
            }
            if (!(TeaNum == "" || TeaNum == null || TeaNum == "0"))
            {
                OrderItem tea = new OrderItem("TEA", Int32.Parse(TeaNum), 3.5);
                items.Add(tea);
            }
            if (!(CoffeeNum == "" || CoffeeNum == null || CoffeeNum == "0"))
            {
                OrderItem coffee = new OrderItem("COFFEE", Int32.Parse(CoffeeNum), 26);
                items.Add(coffee);
            }
            if (!(IphoneNum == "" || IphoneNum == null || IphoneNum == "0"))
            {
                OrderItem iphone = new OrderItem("IPHONE", Int32.Parse(IphoneNum), 12699);
                items.Add(iphone);
            }
            if (!(IpadNum == "" || IpadNum == null || IpadNum == "0"))
            {
                OrderItem ipad = new OrderItem("IPAD", Int32.Parse(IpadNum), 10299);
                items.Add(ipad);
            }
            if (!(PerfumeNum == "" || PerfumeNum == null || PerfumeNum == "0"))
            {
                OrderItem perfume = new OrderItem("PERFUME", Int32.Parse(PerfumeNum), 1099);
                items.Add(perfume);
            }
            Items = items;


        }

    }

}