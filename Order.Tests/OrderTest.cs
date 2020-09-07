using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Order.Tests
{
    public class OrderTest
    {
        [Theory, AutoData]
        public void CanSetCounterparty(Domains.Order.Order order)
        {
            var result = order.OrderRollback();

            if (order.Executor.Balance < order.Amount)
            Assert.Equal(result, false);
        }
    }
}
