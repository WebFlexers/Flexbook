<template>
  <div class="row justify-center items-center">
    <q-page style="max-width: 1500px">
      <div v-if="books.length" class="row justify-start q-pa-lg q-gutter-lg">
        <BookForSale v-for="(bookElement) in filteredBooks" :key="bookElement" :book="bookElement"
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
import {BookDTO} from 'src/types/Books/BookDTO';
import {computed, ref} from 'vue';
import {useSearchStore} from 'stores/search';

let books = ref<Array<BookDTO>>([])

const bookService = new BookService()

bookService.getBooksByGenre('Science').then(allBooks => {
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

</script>
