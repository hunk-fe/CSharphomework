
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderManage
{
    public class InputErrorException : ApplicationException
    {
        public string Description { get; set; }
        public InputErrorException(string description)
        {
            Description = description;
        }
    }

    public class OrderNotExistException : ApplicationException
    {
        public string Description { get; set; }
        public OrderNotExistException(string description)
        {
            Description = description;
        }
    }

    public class OrderItemRepeatException : ApplicationException
    {
        public string Description { get; set; }
        public OrderItemRepeatException(string description)
        {
            Description = description;
        }
    }

    public class OrderRepeatException : ApplicationException
    {
        public string Description { get; set; }
        public OrderRepeatException(string description)
        {
            Description = description;
        }
    }
}
