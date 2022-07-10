<template>
  <div class="row justify-center items-center">
    <q-page style="max-width: 1500px">
      <div v-if="books.length" class="row justify-start q-pa-lg q-gutter-lg">
        <BookForSale v-for="(bookElement) in books" :key="bookElement" :book="bookElement"
                     class="col-md bg-primary-light">
        </BookForSale>
      </div>
      <q-page-scroller position="bottom-right" :scroll-offset="150" :offset="[18, 18]">
        <q-btn fab icon="keyboard_arrow_up" color="secondary" />
      </q-page-scroller>
    </q-page>
  </div>
</template>

<script setup lang="ts">
import BookForSale from 'components/BookForSale.vue';
import BookService from 'src/services/BookService';
import {BookDTO} from 'src/types/BookDTO';
import {ref} from 'vue';

let books = ref<Array<BookDTO>>([])

const bookService = new BookService()

bookService.getBooksByGenre('History').then(allBooks => {
  books.value = allBooks
}).catch((error) => {
  console.log(error)
})

</script>
