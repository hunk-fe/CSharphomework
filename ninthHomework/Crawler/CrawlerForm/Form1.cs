using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using crawler;

namespace CrawlerForm
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
           
        }

        private void Crawler_PageDownloaded(string url)
        {
            if (listBox.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] { url });
            }
            else
            {
                AddUrl(url);
            }
        }

        private void AddUrl(string url)
        {
            listBox.Items.Add(url);
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Crawler crawler = new Crawler(textBox_url.Text);
            listBox.Items.Clear();
            crawler.PageDownloaded += Crawler_PageDownloaded;
            new Thread(crawler.Crawl).Start();
        }
    }
}
