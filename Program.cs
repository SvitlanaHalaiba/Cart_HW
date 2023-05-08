namespace CartSpase
{
    public class Cart
    {
        private string userId;
        private Dictionary<string, int> itemQuantities = new Dictionary<string, int>();
        private Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>();

        public Cart(string userId)
        {
            this.userId = userId;
        }

        public decimal CartAmount
        {
            get
            {
                decimal amount = 0;
                foreach (var item in itemQuantities)
                {
                    amount += item.Value * itemPrices[item.Key];
                }
                return amount;
            }
        }

        public int CartCount
        {
            get { return itemQuantities.Values.Sum(); }
        }

        public void AddItem(string itemId, int quantity, decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Price must be positive", nameof(price));
            }

            if (itemQuantities.TryGetValue(itemId, out int currentQuantity))
            {
                if (itemPrices[itemId] != price)
                {
                    throw new ArgumentException("Cannot change the price of an item that is already in the cart", nameof(price));
                }

                itemQuantities[itemId] += quantity;
            }
            else
            {
                itemQuantities[itemId] = quantity;
                itemPrices[itemId] = price;
            }
        }

        public void RemoveItem(string itemId, int quantity)
        {
            if (itemQuantities.TryGetValue(itemId, out int currentQuantity))
            {
                if (currentQuantity < quantity)
                {
                    throw new ArgumentException("Cannot remove more items than are in the cart", nameof(quantity));
                }

                currentQuantity -= quantity;
                if (currentQuantity == 0)
                {
                    itemQuantities.Remove(itemId);
                    itemPrices.Remove(itemId);
                }
                else
                {
                    itemQuantities[itemId] = currentQuantity;
                }
            }
        }
    }
}
