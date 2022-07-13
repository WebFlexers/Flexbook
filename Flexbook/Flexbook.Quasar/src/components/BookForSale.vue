<template>
  <q-card class="bookCard q-pa-md q-pt-lg">
    <q-img :src="bookImage" alt="book_image" class="row cursor-pointer" fit="scale-down" style="max-height: 200px"
           @click="goToBookPage"/>

    <q-card-section class="underline cursor-pointer" @click="goToBookPage">
      <div class="row text-h6 crop-text-2">
        {{ book.title }}
        <q-tooltip :delay="500" :offset="[0, 5]">
          {{ book.title }}
        </q-tooltip>
      </div>
      <div class="row text-subtitle2 crop-text-2"> by {{ book.author.fullname }}</div>
    </q-card-section>

    <q-card-section class="row cursor-text q-pt-sm">
      <p class="crop-text-3">
        {{ book.description }}
      </p>
    </q-card-section>

    <q-card-section class="row q-ml-md q-mb-md cursor-text absolute-bottom" style="color: grey; ">
        <q-btn style="max-height: 40px" color="primary" @click="addToCart"> Add to Cart </q-btn>
        <p class="q-ml-xl q-mt-sm">
          Price: <span style="color: black; font-weight: bold"> {{ book.startingPrice }}€ </span>
        </p>
    </q-card-section>
  </q-card>
</template>

<script setup lang="ts">
import {computed, defineProps, PropType, ref} from 'vue';
import { BookDTO } from 'src/types/Books/BookDTO';
import {useShoppingCartStore} from 'stores/shopping-cart';
import {useQuasar} from 'quasar';
import {useCurrentBookStore} from 'stores/current-book';
import {useRouter} from 'vue-router';
import {useAuthStore} from 'stores/auth';

const $q = useQuasar()

// Get a BookDTO as prop
const props = defineProps( {
  book: {
    type: Object as PropType<BookDTO>,
    required: true
  }
})

const bookImage = computed(() => {
  if (props.book) {
    return `books/${props.book.image}`
  }

  return undefined
});

const router = useRouter();
// Set this book as the current book in Current Book Store
// and go to the book page
function goToBookPage() {
  let currentBookStore = useCurrentBookStore()
  currentBookStore.book = props.book

  router.push(`/book/${props.book.title.replaceAll(' ', '-')}`)
}

// Add book to shopping cart store
const shoppingCartStore = useShoppingCartStore()
const authStore = useAuthStore()

function addToCart() {
  if (authStore.loggedIn) {
    if (authStore.user.role == 'Customer') {
      // Check if the book is already in the cart and if so increment its quantity by 1
      const bookInCart = shoppingCartStore.shoppingCartItems.find(item => item.book.id == props.book.id)
      if (bookInCart) {
        bookInCart.quantity++

        $q.notify({
          type: 'positive',
          message: `Successfully added another "${props.book.title}" to cart!`,
          timeout: 400
        })

        return
      }

      // Add the book to the Shopping Cart Store
      if (shoppingCartStore.addBookToCart({book: props.book, quantity: 1})) {
        $q.notify({
          type: 'positive',
          message: `Successfully added "${props.book.title}" to cart!`,
          timeout: 400
        })
        console.log('Successfully added "${props.book.title}" to cart!')
        console.log('Quantity ' + shoppingCartStore.shoppingCartItems[0].quantity)
      }
      else {
        $q.notify({
          type: 'negative',
          message: 'Failed to add book to cart...'
        })
      }
    }
    else {
      $q.notify({
        type: 'negative',
        message: 'Only customers can make orders!',
        timeout: 1500
      })
    }
  }
  else {
    $q.notify({
      type: 'negative',
      message: 'Please login in order to add items to your cart!',
      timeout: 1500
    })
  }
}
</script>

<style scoped lang="scss">
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.bookCard {
  min-width: 340px;
  max-width: 340px;
  height: 530px;
}

.bookCard:hover {
  border-style: solid;
  border-color: $primary;
  border-width: 1px;
}

.bookDescription {
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
