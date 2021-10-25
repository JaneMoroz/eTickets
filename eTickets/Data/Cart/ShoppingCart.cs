using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(Movie movie)
        {
            //Check if the movie already in the cart
            var shoppingCartItem = _context.ShoppingCartItems
                .FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            //If no, add it to the shopping cart items
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            //If yes, just add 1 to the movie amount
            else
            {
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }
        public void RemoveItemFromCart(Movie movie)
        {
            //Check if the shopping cart item exists in the database
            var shoppingCartItem = _context.ShoppingCartItems
                .FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            //If it exists
            if (shoppingCartItem != null)
            {
                //And if the amount greater than one, we need to decrease the amount by one
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                //And if the amount is equal to 1, we need to remove the item from the database
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }

            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId).Include(x => x.Movie).ToList());
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .Select(x => x.Movie.Price * x.Amount).Sum();
            return total;
        }
    }
}
