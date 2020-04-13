using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderManage
{
    public class OrderItem
    {
        public int tradeNum { get; set; }
        public string tradeName { get; set; }
        public double tradeUnitPrice { get; set; }

        public double tradeSumPrice
        {
            get
            {
                return tradeNum * tradeUnitPrice;
            }
        }
        public OrderItem()
        {
            tradeNum = 0;
            tradeName = null;
            tradeUnitPrice = 0;

        }
        public OrderItem(string tradeName, int tradeNum, double tradeUnitPrice)
        {
            if (tradeNum > 0 && tradeUnitPrice > 0)
            {
                this.tradeNum = tradeNum;
                this.tradeName = tradeName;
                this.tradeUnitPrice = tradeUnitPrice;
            }
            else
            {
                throw new InputErrorException(tradeName);
            }
        }

        public override bool Equals(object obj)
        {
            OrderItem orderitem = obj as OrderItem;
            return orderitem != null && orderitem.tradeName == tradeName && orderitem.tradeNum == tradeNum && orderitem.tradeUnitPrice == tradeUnitPrice;
        }

        public override int GetHashCode()
        {
            return tradeNum;
        }

        public override string ToString()
        {
            return "" + tradeName + "             " + tradeUnitPrice + "             " + tradeNum + "\n";
        }
    }
}
