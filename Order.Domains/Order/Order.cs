using Order.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domains.Order
{
    public class Order : AggregateRootBase
    {

        public int Id { get; set; }
        public int СustomerId { get; set; }
        public User Customer { get; set; }
        public int ExecutorId { get; set; }
        public User Executor { get; set; }
        public string Ditails { get; set; }
        public int Amount { get; set; }
        public bool IsPayment { get; set; }


        public bool OrderRollback()
        {

            if (Executor.Balance < Amount || IsPayment == false)
            {
                return false;
            }

            Executor.Balance = Executor.Balance - Amount;
            Customer.Balance = Customer.Balance + Amount;
            IsPayment = false;

            return true;
        }


    }
}
