import {defineStore} from 'pinia';
import {ShoppingCartBook} from 'src/types/Orders/ShoppingCartBook';

interface ShoppingCartStore {
  shoppingCartItems: ShoppingCartBook[]
}

export const useShoppingCartStore = defineStore({
  id: 'shopping-cart',
  state: (): ShoppingCartStore => ({
    shoppingCartItems: []
  }),

  getters: {
    getShoppingCartItems(): ShoppingCartBook[] {
      return this.shoppingCartItems
    }
  },

  actions: {
    addBookToCart(cartItem: ShoppingCartBook): boolean {
      if (cartItem) {
        this.shoppingCartItems.push(cartItem)
        return true
      }

      console.error('Failed to add book to shopping cart!')
      return false
    },

    removeBookFromCart(index: number): boolean {
      if (index > -1) {
        this.shoppingCartItems.splice(index, 1);
        return true
      }

      console.error('Failed to delete book from shopping cart!')
      return false
    },

    clearCart() {
      this.shoppingCartItems = []
    },

    calculateTotalPrice() {
      let sum = 0
      this.shoppingCartItems.forEach((item) => {
        sum += item.book.startingPrice
      })
      return sum
    }
  }
})
