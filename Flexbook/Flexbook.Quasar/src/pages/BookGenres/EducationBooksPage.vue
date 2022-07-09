<template>
  <div v-if="books.length" class="q-ma-lg q-gutter-lg row justify-start"
       style="margin-left: 20em; margin-right: 20em">
    <div v-for="(bookElement) in books" :key="bookElement">
      <BookForSale class="bg-primary-light col" :book="bookElement"></BookForSale>
    </div>
  </div>

</template>

<script setup lang="ts">
import BookForSale from 'components/BookForSale.vue';
import BookService from 'src/services/BookService';
import {BookDTO} from 'src/types/BookDTO';
import {ref} from 'vue';

let books = ref<Array<BookDTO>>([])

const bookService = new BookService()

bookService.getBooksByGenre('Education').then(allBooks => {
  books.value = allBooks
}).catch((error) => {
  console.log(error)
})

</script>
