import {defineStore} from 'pinia';
import {ShoppingCartBook} from 'src/types/Orders/ShoppingCartBook';
import {OrderItemDTO} from 'src/types/Orders/OrderItemDTO';

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
    },

    getItemsAsOrderItemDTOs(): OrderItemDTO[] {
      const orderItemDTOs: OrderItemDTO[] = []

      this.shoppingCartItems.forEach((item) => {
        const quantity = item.quantity
        const productId = item.book.id
        orderItemDTOs.push({quantity, productId} as OrderItemDTO)
      })

      return orderItemDTOs
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
        if (item.quantity > 0) {
          sum += item.book.startingPrice * item.quantity
        }
      })
      // Round to 2 decimal places
      return Math.round(sum * 100) / 100
    }
  }
})
