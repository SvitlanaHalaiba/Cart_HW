using CartSpase;
using NUnit.Framework;

namespace CartSpace
{

    [TestFixture]
    public class CartTests
    {
        private Cart cart;

        [Test]
        public void AddItem_WhenCalled_AddsItemToCart()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId = "item1";
            int quantity = 1;
            decimal price = 10;

            // Act
            cart.AddItem(itemId, quantity, price);

            // Assert
            Assert.AreEqual(quantity, cart.CartAmount(itemId);      
        }

        [Test]
        public void AddItem_WhenPriceIsNegative_ThrowsArgumentException()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId = "item1";
            int quantity = 1;
            decimal price = -10;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => cart.AddItem(itemId, quantity, price));
        }

        [Test]
        public void AddItem_WhenItemIsAlreadyInCart_UpdatesQuantity()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId = "item1";
            int quantity1 = 1;
            int quantity2 = 2;
            decimal price = 10;

            // Act
            cart.AddItem(itemId, quantity1, price);
            cart.AddItem(itemId, quantity2, price);

            // Assert
            Assert.AreEqual(quantity1 + quantity2, cart.CartAmount);
        }

        [Test]
        public void AddItem_WhenPriceOfExistingItemChanges_ThrowsArgumentException()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId = "item1";
            int quantity1 = 1;
            int quantity2 = 2;
            decimal price1 = 10;
            decimal price2 = 20;

            // Act
            cart.AddItem(itemId, quantity1, price1);

            // Assert
            Assert.Throws<ArgumentException>(() => cart.AddItem(itemId, quantity2, price2));
        }

        [Test]
        public void RemoveItem_WhenCalled_RemovesItemFromCart()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId = "item1";
            int quantity = 1;
            decimal price = 10m;
            cart.AddItem(itemId, quantity, price);

            // Act
            cart.RemoveItem(itemId, quantity);

            // Assert
            Assert.AreEqual(0, cart.CartAmount);
        }

        [Test]
        public void RemoveItem_WhenItemIsNotInCart_DoesNotRemoveAnything()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId1 = "item1";
            string itemId2 = "item2";
            int quantity = 1;
            decimal price = 10;
            cart.AddItem(itemId1, quantity, price);

            // Act
            cart.RemoveItem(itemId2, quantity);

            // Assert
            Assert.AreEqual(quantity, cart.CartAmount);
        }

        [Test]
        public void RemoveItem_WhenRequestedQuantityIsGreaterThanCurrentQuantity_ThrowsArgumentException()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId = "item1";
            int quantity1 = 1;
            int quantity2 = 2;
            decimal price = 10;
            cart.AddItem(itemId, quantity1, price);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => cart.RemoveItem(itemId, quantity2));
        }

        [Test]
        public void CartAmount_WhenCalled_CalculatesCorrectTotalCost()
        {
            // Arrange
            string userId = "user1";
            Cart cart = new Cart(userId);
            string itemId1 = "item1";
            string itemId2 = "item2";
            int quantity1 = 1;
            int quantity2 = 2;
            decimal price1 = 10;
            decimal price2 = 20;
            decimal expectedAmount = quantity1 * price1 + quantity2 * price2;
            cart.AddItem(itemId1, quantity1, price1);
            cart.AddItem(itemId2, quantity2, price2);

            // Act
            decimal actualAmount = cart.CartAmount;

            // Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }
    }
}

