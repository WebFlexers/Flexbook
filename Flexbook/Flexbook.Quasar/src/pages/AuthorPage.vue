<template>
  <div>
    <h1> Hello from the other side! </h1>
  </div>
</template>

<script setup lang="ts">
import {ref} from 'vue';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';
import {useCurrentAuthorStore} from 'stores/current-author';
import BookService from 'src/services/BookService';
import {useRoute, useRouter} from 'vue-router';

const author = ref({} as AuthorDTO)

const route = useRoute()
const router = useRouter()
const currentAuthorStore = useCurrentAuthorStore()
// Get the author from the store if it exists
if (currentAuthorStore.author.fullname) {
  author.value = currentAuthorStore.getAuthor
}
else {
  // Try to get the author from the api using the page url
  const bookService = new BookService()
  bookService.getAuthorByEmail(route.params.title.toString()).then((foundBook) => {
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
</script>

<style scoped>

</style>
