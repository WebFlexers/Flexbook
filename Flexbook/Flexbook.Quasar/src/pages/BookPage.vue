<template>
  <div class="row justify-center items-center q-mb-xl">
    <div class="bg-primary-light q-mt-xl q-pb-xl" style="max-width: 1200px; border-radius: 15px;">
      <div class="row justify-center">
        <div class="col-4 row justify-center">
          <q-img :src="bookImage" alt="book_image" fit="contain" class="q-ma-lg" style="max-height: 450px"/>
          <q-btn style="max-height: 50px" color="primary" @click="returnToHome"> Back to home </q-btn>
        </div>
        <div class="col-8 q-mt-xl q-pr-xl q-pl-md">
          <p class="text-bold" style="font-size: 1.7em"> {{ book.title }} </p>
          <p> <span class="font-complementary">Description:</span> {{ book.description}} </p>

          <p> <span class="text-semi-bold"> ISBN: </span> {{ book.isbn }} </p>
          <p> <span class="text-semi-bold"> Genre: </span> {{ book.genre }} </p>
          <p> <span class="text-semi-bold"> Publisher: </span> {{ book.publisher }} </p>
          <p> <span class="text-semi-bold"> Pages: </span> {{ book.pageCount }} </p>
          <p> <span class="text-semi-bold"> language: </span> {{ book.language }} </p>

          <q-separator/>

          <p class="font-complementary"> Summary: </p>
          <p> {{ book.summary }}</p>

          <div class="row justify-center items-center">
            <q-btn color="primary" @click="addToCart"> Add to Cart </q-btn>
          </div>
        </div>
      </div>

      <div v-if="bookReviews.length >= 1">
        <div class="row justify-center q-mt-xl">
          <p class="text-semi-bold" style="font-size: 1.7em"> Reviews: </p>
        </div>

        <div class="row justify-center">
          <div class="row justify-start q-gutter-md" style="max-width: 1000px">
            <div class="q-px-xl" v-for="(review) in bookReviews" :key="review">
              <BookReview :bookReview="review"/>
            </div>
          </div>
        </div>
      </div>

      <div class="row justify-center q-mt-xl" v-if="bookReviews.length <= 0">
        <h5> This book doesn't have any reviews yet! </h5>
      </div>

      <div v-if="authStore.user.role === 'Customer'">
        <div class="row justify-center q-mt-xl">
          <p class="text-semi-bold q-mt-lg" style="font-size: 1.7em"> Write your own review: </p>
        </div>

        <div class="row justify-center">
          <q-editor v-model="userReview.content" min-height="5rem" />
        </div>

        <div class="row justify-center q-mt-sm">
          <p class="text-semi-bold q-mt-lg" style="font-size: 1.4em"> Your rating: </p>
        </div>
        <div class="row justify-center">
          <q-rating
            v-model="userReview.rating"
            size="2em"
          />
        </div>

        <div class="row justify-center q-mt-xl">
          <q-btn color="primary" style="width: 200px" @click="submitReview"> Submit review </q-btn>
        </div>
      </div>

    </div>
  </div>
</template>

<script setup lang="ts">
import {computed, ref} from 'vue';
import {BookDTO} from 'src/types/Books/BookDTO';
import {useCurrentBookStore} from 'stores/current-book';
import BookService from 'src/services/BookService';
import {useRoute, useRouter} from 'vue-router';
import {useShoppingCartStore} from 'stores/shopping-cart';
import {useAuthStore} from 'stores/auth';
import {useQuasar} from 'quasar';
import {BookReviewDTO} from 'src/types/Books/BookReviewDTO';
import BookReviewService from 'src/services/BookReviewService';
import BookReview from 'components/BookReview.vue';
import {AddBookReviewDTO} from 'src/types/Books/AddBookReviewDTO';

const $q = useQuasar()
const book = ref({} as BookDTO)
const bookReviews = ref<BookReviewDTO[]>({} as BookReviewDTO[])
const userReview = ref({} as AddBookReviewDTO)
userReview.value.rating = 3
userReview.value.content = ''

const currentBookStore = useCurrentBookStore()
const route = useRoute()
const router = useRouter()

if (currentBookStore.book.title) {
  book.value = currentBookStore.getBook
  fetchBookReviews()
}
else {
  // Get the book from the api
  const bookService = new BookService()
  bookService.getBookByName(route.params.title.toString()).then((foundBook) => {
    if (foundBook) {
      book.value = foundBook
    }
    else {
      router.push('/error-not-found-page')
      return
    }

    fetchBookReviews()

  }).catch((error) => {
    console.error(error)
    router.push('/error-not-found-page')
  })
}

function fetchBookReviews() {
  // Get all book reviews
  const bookReviewService = new BookReviewService()
  bookReviewService.getAllReviewsOfBook(book.value.id).then((result) => {
    bookReviews.value = result
  }).catch((error) => {
    console.error(error)
  })
}

function submitReview() {
  if (userReview.value.content) {

    userReview.value.userId = authStore.user.id
    userReview.value.bookId = book.value.id

    const bookReviewService = new BookReviewService()
    bookReviewService.addReview(userReview.value).then(() => {
      $q.notify({
        type: 'positive',
        message: 'Your review has been submitted!',
        timeout: 1500
      })
    })
  }
  else {
    $q.notify({
      type: 'negative',
      message: 'The review text can\'t be empty!',
      timeout: 1500
    })
  }
}

const bookImage = computed(() => {
  if (book.value) {
    return `books/${book.value.image}`
  }

  return undefined
});

// Return to home page
function returnToHome() {
  router.push('/')
}

// Add book to shopping cart store
const shoppingCartStore = useShoppingCartStore()
const authStore = useAuthStore()

function addToCart() {
  if (authStore.loggedIn) {
    if (authStore.user.role == 'Customer') {
      // Check if the book is already in the cart and if so increment its quantity by 1
      const bookInCart = shoppingCartStore.shoppingCartItems.find(item => item.book.id == book.value.id)
      if (bookInCart) {
        bookInCart.quantity++

        $q.notify({
          type: 'positive',
          message: `Successfully added another "${book.value.title}" to cart!`,
          timeout: 400
        })

        return
      }

      // Add the book to the Shopping Cart Store
      if (shoppingCartStore.addBookToCart({book: book.value, quantity: 1})) {
        $q.notify({
          type: 'positive',
          message: `Successfully added "${book.value.title}" to cart!`,
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

<style lang="scss">
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.bg-primary-light {
  background-color: $primary-light;
}

.font-complementary {
  color: $secondary-light;
  font-weight: 600;
  font-size: 1.2em;
}

.text-semi-bold {
  font-weight: 500;
}
</style>
