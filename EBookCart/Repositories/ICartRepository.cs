namespace EBookCart.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int bookId, int qty);
        Task<int> RemoveItem(int bookId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userID = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout();

    }
}
