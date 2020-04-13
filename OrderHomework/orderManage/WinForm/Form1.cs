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
using static WinForm.Form3;

namespace WinForm
{
    public partial class Form1 : Form
    {


        public OrderService os = new OrderService();
        public List<Order> orders;
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();

            Order order1 = new Order(1,"Customer1", "China");
            Order order2 = new Order(2,"Customer2", "Canada");
            Order order3 = new Order(3,"Customer3", "Japan");

            order1.AddOrderItem("APPLE", 10, 7.2);
            order1.AddOrderItem("GRAPE", 10, 8.7);
            order1.AddOrderItem("TEA", 20, 3.5);

            order2.AddOrderItem("COFFEE", 10, 26);
            order2.AddOrderItem("IPHONE", 2, 12699);
            order2.AddOrderItem("IPAD", 1, 10299);

            order3.AddOrderItem("PERFUME", 1, 1099);

            os.orderList.Add(order1);
            os.orderList.Add(order2);
            os.orderList.Add(order3);
            orders = os.orderList;
            orderBindingSource.DataSource = orders;

            //绑定查询条件
            mainWordText.DataBindings.Add("Text", this, "KeyWord");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            switch (searchWay.SelectedItem.ToString())
            {
                case "商品名称":
                    if (KeyWord == null || KeyWord == "")
                    {
                        orderBindingSource.DataSource = orders;
                    }
                    else
                    {
                        orderBindingSource.DataSource =
                            os.QueryOrdersByGoodsName(KeyWord);
                    }
                    orderBindingSource.ResetBindings(false);
                    itemBindingSource.ResetBindings(false);
                    break;

                case "客户名称":
                    if (KeyWord == null || KeyWord == "")
                    {
                        orderBindingSource.DataSource = orders;
                    }
                    else
                    {
                        orderBindingSource.DataSource =
                            os.QueryOrdersByCustomerName(KeyWord);
                    }
                    orderBindingSource.ResetBindings(false);
                    itemBindingSource.ResetBindings(false);
                    break;
                case "订单价格":
                    os.Sort((o1, o2) => o1.sumPrice.CompareTo(o2.sumPrice));
                    orders = os.orderList;
                    orderBindingSource.DataSource = orders;
                    orderBindingSource.ResetBindings(false);
                    itemBindingSource.ResetBindings(false);
                    break;
                default:
                    break;
            }
        }

        public void CreateOrder(object sender, CreateOrderEventArgs args)
        {
            Order order = new Order(args.orderID,args.client, args.address);
            order.orderNum = args.orderID;

            foreach (OrderItem item in args.Items)
            {
                order.orderItemList.Add(item);
            }

            // 更新窗体控件
            if (orders.Contains(order))
                MessageBox.Show($"Add Order Error: Order with id {order.orderNum} already exists!");
            os.orderList.Add(order);
        }

        private void orderInBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "C# Corner Open File Dialog";
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Filter = "All files（*.xml*）|*.xml";
            /*
             * FilterIndex 属性用于选择了何种文件类型,缺省设置为0,系统取Filter属性设置第一项
             * ,相当于FilterIndex 属性设置为1.如果你编了3个文件类型，当FilterIndex ＝2时是指第2个.
             */
            openFileDialog1.FilterIndex = 2;
            /*
             *如果值为false，那么下一次选择文件的初始目录是上一次你选择的那个目录，
             *不固定；如果值为true，每次打开这个对话框初始目录不随你的选择而改变，是固定的  
             */
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                os.Import(System.IO.Path.GetFullPath(openFileDialog1.FileName));
                //System.IO.Path.GetFullPath(openFileDialog1.FileName); //绝对路径
                //System.IO.Path.GetExtension(openFileDialog1.FileName); //文件扩展名
                //System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName); //文件名没有扩展名
                //System.IO.Path.GetFileName(openFileDialog1.FileName); //得到文件
                //System.IO.Path.GetDirectoryName(openFileDialog1.FileName); //得到路径
            }

        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(os.orderList);
            f3.Owner = this; //设置查找窗体的父窗体为本窗体
            f3.UpdateOrder += new Form3.UpdateOrderHandler(UpdateOrder);
            f3.ShowDialog();
            orderBindingSource.ResetBindings(false);
            /*Order orde = new Order(3, "Customer2", new List<OrderItem> { apple, milk });

            os.AddOrder(order1);*/
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int position = orderBindingSource.Position;
            //string orderid = Convert.ToString(dataGridView1.Rows[position].Cells[0].Value);
            //MessageBox.Show(orderid);
            os.DeleteOrder(Convert.ToString(dataGridView1.Rows[position].Cells[1].Value));
            orderBindingSource.ResetBindings(false);
        }

        private void getOrderBtn_Click(object sender, EventArgs e)
        {
            //string localFilePath, fileNameExt, newFileName, FilePath;
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型
            sfd.Filter = "orders（*.xml）|*.xml";

            //设置默认文件类型显示顺序
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;

            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                string localFilePath = sfd.FileName.ToString(); //获得文件路径
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                os.Export(localFilePath);
                //获取文件路径，不带文件名
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                //给文件名前加上时间
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                //在文件名里加字符
                //saveFileDialog1.FileName.Insert(1,"dameng");

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                ////fs输出带文字或图片的文件，就看需求了
            }
        }
        public void UpdateOrder(object sender, UpdateOrderEventArgs args)

        {
            Order order = new Order(args.orderNum,args.client, args.address);
            order.orderNum = args.orderNum;

            foreach (OrderItem item in args.Items)
            {
                order.orderItemList.Add(item);
            }

            // 更新窗体控件
            if (!(orders.Contains(order)))
                MessageBox.Show($"Update Order Error: Order with id {order.orderNum} did not exists!");
            os.UpdateOrder(order);

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this; //设置查找窗体的父窗体为本窗体
            f.CreateOrder += new Form2.CreateOrderHandler(CreateOrder);
            f.ShowDialog();
            orderBindingSource.ResetBindings(false);
            /*Order orde = new Order(3, "Customer2", new List<OrderItem> { apple, milk });

            os.AddOrder(order1);*/
        }
    }
}
