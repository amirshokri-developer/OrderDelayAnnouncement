namespace OrderDelayAnnouncement.Domain.Tests.Unit
{
    public class OrderTests
    {
        private readonly OrderTestBuilder _orderTestBuilder;
        

        public OrderTests()
        {
            _orderTestBuilder = new OrderTestBuilder();
            
        }

        [Fact]
        public void CreatedTime_Should_Be_Bigger_Than_DeliveredTime()
        {
            var order = _orderTestBuilder.WithId(OrderIdConsts.Default)
                .WithCustomer(CustomerConsts.Amir)
                .WithVendor(VendorConsts.Shiraz)
                .WithCreatedTime(DateTime.Now)
                .WithDeliveredTime(DateTime.Now.AddMinutes(50))
                .Build();

            Assert.True( order.CreatedTime <  order.DeliveredTime , "not valid deliver time");

        }
    }

}