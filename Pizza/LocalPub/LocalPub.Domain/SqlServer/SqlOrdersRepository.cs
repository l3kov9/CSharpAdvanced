using LocalPub.Domain.Interfaces;
using LocalPub.Models.BindingModels;
using LocalPub.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace LocalPub.Domain.SqlServer
{
    public class SqlOrdersRepository : DbRepository, IOrdersRepository
    {
        public SqlOrdersRepository()
        {
        }

        public SqlOrdersRepository(string connectionString)
            : base(connectionString)
        {
        }

        public ICollection<OrderViewModel> GetAllOrdersForClient(int clientId)
        {
            var reader = this.ExecuteReader(
                    @"select
	                    o.Id as OrderId,
	                    o.OrderDate,
	                    o.IsCancelled,
	                    m.Name as MealName
                    from Orders as o
                    join OrderMeals as om
                    on om.OrderId = o.Id
                    join Meals as m
                    on om.MealId = m.Id
                    where ClientId = @clientId
                    order by o.OrderDate",
                    new Dictionary<string, object> { { "@clientId", clientId } });
            var orders = new Dictionary<int, OrderViewModel>();
            using (reader)
            {
                while (reader.Read())
                {
                    int orderId = reader.GetInt32(0);
                    var orderDate = reader.GetDateTime(1);
                    bool isCancelled = reader.GetBoolean(2);
                    string mealName = reader.GetString(3);

                    if (!orders.ContainsKey(orderId))
                    {
                        orders[orderId] = new OrderViewModel(orderId, orderDate, isCancelled);
                    }

                    orders[orderId].Meals.Add(mealName);
                }
            }

            return orders.Values;
        }

        public int GetNumberOfOrdersForClient(int clientId, DateTime date)
        {
            int count = (int)this.ExecuteScalar(
                    @"select count(*) as OrdersCount
                    from Orders
                    where OrderDate = @date
                    and ClientId = @clientId
                    and Orders.IsCancelled = 0",
                    new Dictionary<string, object>()
                    {
                        {"@date", date },
                        {"@clientId", clientId }
                    });
            return count;
        }

        public int GetOrderClient(int orderId)
        {
            int clientId = (int)this.ExecuteScalar(
                @"select ClientId
                from Orders
                where Id = @orderId",
                new Dictionary<string, object>()
                {
                    { "@orderId", orderId }
                });

            return clientId;
        }

        public bool SaveOrder(OrderBindingModel order)
        {
            int orderId = (int)this.ExecuteScalar(
                @"insert into Orders
                    (ClientId, OrderDate, IsCancelled)
                output INSERTED.ID
                values (@clientId, @date, 0)",
                new Dictionary<string, object>()
                    {
                        {"@date", order.OrderDate },
                        {"@clientId", order.ClientId }
                });

            if (orderId <= 0)
            {
                return false;
            }

            string query = string.Empty;
            var queryParams = new Dictionary<string, object>()
            {
                { "@orderId", orderId }
            };

            if (order.AppetizerId.HasValue)
            {
                query +=
                    @"insert into OrderMeals (OrderId, MealId)
                    values (@orderId, @appetizerId)";
                queryParams.Add("@appetizerId", order.AppetizerId.Value);
            }

            if (order.MainCourseId.HasValue)
            {
                query += Environment.NewLine +
                    @"insert into OrderMeals (OrderId, MealId)
                    values (@orderId, @mainCourseId)";
                queryParams.Add("@mainCourseId", order.MainCourseId.Value);
            }

            if (order.DessertId.HasValue)
            {
                query += Environment.NewLine +
                    @"insert into OrderMeals (OrderId, MealId)
                    values (@orderId, @dessertId)";
                queryParams.Add("@dessertId", order.DessertId.Value);
            }

            if (order is PrivilegedUserOrderBindingModel)
            {
                var privilegedOrder = order as PrivilegedUserOrderBindingModel;
                if (privilegedOrder.AdditionalDessertId.HasValue)
                {
                    query += Environment.NewLine +
                        @"insert into OrderMeals (OrderId, MealId)
                        values (@orderId, @additionalDessertId)";
                    queryParams.Add("@additionalDessertId", privilegedOrder.AdditionalDessertId.Value);
                }
            }

            return this.ExecuteNonQuery(query, queryParams) > 0;
        }

        public bool CancelOrder(int orderId)
        {
            int numberOfRows = this.ExecuteNonQuery(
                @"update Orders
                set IsCancelled = 1
                where Id = @orderId",
                new Dictionary<string, object>()
                {
                    {"@orderId", orderId },
                });
            return numberOfRows > 0;
        }
    }
}
