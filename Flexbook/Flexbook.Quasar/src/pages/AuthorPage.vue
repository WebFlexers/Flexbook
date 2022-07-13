<template>
  <div>
    <h1> {{ author.fullname }} </h1>
  </div>
</template>

<script setup lang="ts">
import {ref} from 'vue';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';
import {useCurrentAuthorStore} from 'stores/current-author';
import {useRoute, useRouter} from 'vue-router';
import AuthorService from 'src/services/AuthorService';

const author = ref({} as AuthorDTO)

const route = useRoute()
const router = useRouter()
const currentAuthorStore = useCurrentAuthorStore()

// Get the author from the store if it exists
if (currentAuthorStore.author.fullname) {
  author.value = currentAuthorStore.getAuthor
  console.log('Authors full name is ' + author.value.fullname)
}
else {
  // Try to get the author from the api using the page url
  const authorService = new AuthorService()
  authorService.getAuthorByName(route.params.fullname.toString()).then((foundAuthor) => {
    if (foundAuthor) {
      author.value = foundAuthor
    }
    else {
      router.push('/error-not-found-page')
      return
    }

  }).catch((error) => {
    console.error(error)
    router.push('/error-not-found-page')
  })
}
</script>

<style scoped>

</style>
