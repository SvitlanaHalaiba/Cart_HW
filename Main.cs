using CartSpase;
static void Main(string[] args)
{
    // Create a new cart with the user ID "test"
    Cart cart = new Cart("test");

    // Add some items to the cart
    cart.AddItem("item1", 2, 10.99m);
    cart.AddItem("item2", 1, 5.99m);

    // Print the total cost of the cart
    Console.WriteLine("Cart total: " + cart.CartAmount.ToString("C"));
}