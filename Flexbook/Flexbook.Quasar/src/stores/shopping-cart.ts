import {defineStore} from 'pinia';

interface ShoppingCartStore {
  test: boolean
}

export const useShoppingCartStore = defineStore({
  id: 'shopping-cart',
  state: (): ShoppingCartStore => ({
    test: false
  }),
})
