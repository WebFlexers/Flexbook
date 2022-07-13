<template>
  <div class="row justify-center items-center">
    <q-page style="max-width: 1500px">
      <div class="row justify-center">
        <h3> Available Books </h3>
      </div>

      <div v-if="books.length" class="row justify-start q-pa-lg q-gutter-lg">
          <BookForSale v-for="(bookElement) in filteredBooks" :key="bookElement" :book="bookElement"
                       class="col-md bg-primary-light">
          </BookForSale>
      </div>

      <div class="row justify-center">
        <h3> Available Authors </h3>
      </div>

      <div v-if="authors.length" class="row justify-start q-pa-lg q-gutter-lg">
        <AuthorMini v-for="(authorElement) in authors" :key="authorElement" :author="authorElement"
                     class="col-md bg-primary-light">
        </AuthorMini>
      </div>

      <q-page-scroller position="bottom-right" :scroll-offset="150" :offset="[18, 18]">
        <q-btn fab icon="keyboard_arrow_up" color="secondary" />
      </q-page-scroller>
    </q-page>
  </div>
</template>

<script setup lang="ts">
import BookForSale from 'components/BookForSale.vue';
import { useSearchStore } from 'src/stores/search';
import BookService from 'src/services/BookService';
import {BookDTO} from 'src/types/Books/BookDTO';
import {computed, ref} from 'vue';
import AuthorService from 'src/services/AuthorService';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';
import AuthorMini from 'components/AuthorMini.vue';

let books = ref<Array<BookDTO>>([])

// Get books from api
const bookService = new BookService()
bookService.getAllBooks().then(allBooks => {
  books.value = allBooks
}).catch((error) => {
  console.log(error)
})


const searchStore = useSearchStore()
// Filters the books according to search criteria
const filteredBooks = computed(() => {
  if (searchStore.getUserSearch) {
    // console.log('User search modified to: ' + searchStore.getUserSearch)
    switch (searchStore.getSearchType) {
      case 'Title': {
        return books.value
          .filter (
            ({ title }) => [title]
              .some(val => val.toLowerCase().includes(searchStore.getUserSearch.toLowerCase()))
          );
      }
      case 'Publisher': {
        return books.value
          .filter (
            ({ publisher }) => [publisher]
              .some(val => val.toLowerCase().includes(searchStore.getUserSearch.toLowerCase()))
          );
      }
      case 'Author': {
        return books.value
          .filter (
            ({ author }) => [author]
              .some(val => val.fullname.toLowerCase().includes(searchStore.getUserSearch.toLowerCase()))
          );
      }
      case 'Language': {
        return books.value
          .filter (
            ({ language }) => [language]
              .some(val => val.toLowerCase().includes(searchStore.getUserSearch.toLowerCase()))
          );
      }
      default: {
        return books.value
      }
    }
  }
  else {
    return books.value
  }
})

let authors = ref<Array<AuthorDTO>>([])
// Get books from api
const authorService = new AuthorService()
authorService.getAllAuthors().then(allAuthors => {
  authors.value = allAuthors
}).catch((error) => {
  console.log(error)
})

</script>
