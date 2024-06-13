using Microsoft.AspNetCore.Http;

using MovieStoreMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreMVC.Services
{
    public class ShoppingCartService
    {
        private readonly MovieStoreContext _context;
        private readonly ISession _session;

        public ShoppingCartService(MovieStoreContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
        }

        private const string CartSessionKey = "ShoppingCart";

        public void AddToCart(int movieId)
        {
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.MovieId == movieId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { MovieId = movieId, Quantity = 1 });
            }
            SaveCart(cart);
        }

        public List<CartItem> GetCart()
        {
            var cart = _session.GetString(CartSessionKey);
            if (cart == null)
            {
                return new List<CartItem>();
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartItem>>(cart);
        }

        private void SaveCart(List<CartItem> cart)
        {
            _session.SetString(CartSessionKey, Newtonsoft.Json.JsonConvert.SerializeObject(cart));
        }
    }

    public class CartItem
    {
        public int MovieId { get; set; }
        public int Quantity { get; set; }
    }
}
