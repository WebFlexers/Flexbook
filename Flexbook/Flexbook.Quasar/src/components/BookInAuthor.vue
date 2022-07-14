<template>
  <q-card class="bookCard q-pa-md q-pt-lg" style="max-width: 400px">
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

    <q-card-section class="row q-ml-md q-mb-md cursor-text" style="font-weight: bold;">
      <p> Total times bought:  {{ timesBought }} </p>
    </q-card-section>
  </q-card>
</template>

<script setup lang="ts">
// Get a BookDTO as prop
import {computed, defineProps, PropType} from 'vue';
import {BookDTO} from 'src/types/Books/BookDTO';
import {useRouter} from 'vue-router';
import {useCurrentBookStore} from 'stores/current-book';

const props = defineProps( {
  book: {
    type: Object as PropType<BookDTO>,
    required: true
  },
  timesBought: {
    type: Number,
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
</script>

<style scoped>

</style>
