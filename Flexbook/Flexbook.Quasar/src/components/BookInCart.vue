<template>
  <div class="row justify-start q-pa-lg" style="width: 400px; max-height: 300px">
    <div class="col-6 row justify-center">
      <q-img :src="bookImage" alt="book_image" class="row cursor-pointer" fit="scale-down" style="height: 150px"/>
    </div>

    <div class="col-6 q-pl-md">
      <div class="row justify-center">
        <p class="crop-text-2"> {{ shoppingCartBook.book.title }} </p>
        <q-input dense filled type="number" v-model.number="bookQuantity"/>
        <q-btn class="q-mt-md" round size="md" color="deep-orange" icon="close" @click="removeBookFromCart" />
      </div>
    </div>
  </div>

</template>

<script setup lang="ts">
import {computed, defineProps, PropType, ref, watch} from 'vue';
import { ShoppingCartBook } from 'src/types/Orders/ShoppingCartBook';
import { useShoppingCartStore } from 'stores/shopping-cart';

const bookImage = computed(() => {
  if (props.shoppingCartBook.book) {
    return `books/${props.shoppingCartBook.book.image}`
  }

  return undefined
});

const props = defineProps( {
  shoppingCartBook: {
    type: Object as PropType<ShoppingCartBook>,
    required: true
  }
})

const bookQuantity = ref(props.shoppingCartBook.quantity)

const shoppingCartStore = useShoppingCartStore()
watch(bookQuantity, (newQuantity) => {
  console.log(`New quantity is ${newQuantity.toString()}`)
  let index = shoppingCartStore.getShoppingCartItems.findIndex(element => element.book.id == props.shoppingCartBook.book.id)
  shoppingCartStore.getShoppingCartItems[index].quantity = newQuantity

  // Delete if the quantity is set to 0
    if (shoppingCartStore.getShoppingCartItems[index].quantity === 0) {
      shoppingCartStore.removeBookFromCart(index)
    }
})

function removeBookFromCart() {
  // Set the quantity to 0 and get deleted through the watcher
  bookQuantity.value = 0
}


</script>

<style scoped>

</style>
