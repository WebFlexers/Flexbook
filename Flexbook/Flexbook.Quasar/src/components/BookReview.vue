<template>
  <div class="q-px-lg q-pt-lg bg-whitesmoke" style="border-radius: 20px">
    <div class="row justify-start">
      <div >
        <q-avatar size="50px">
          <q-img :src="userImage" alt="user_image"/>
        </q-avatar>
      </div>
      <div class="q-ml-md q-gutter-sm">
        <q-rating
          v-model="bookReview.rating"
          size="1em"
          readonly
        />
        <p> {{ bookReview.user.fullname }} </p>
      </div>
    </div>

    <q-separator class="q-mb-md q-mt-sm"/>

    <div class="row">
      <p v-html="bookReview.content"/>
<!--      <p> {{bookReview.content}} </p>-->
    </div>
  </div>
</template>

<script setup lang="ts">
import {computed, defineProps, PropType} from 'vue';
import {BookReviewDTO} from 'src/types/BookReviewDTO';

// Get a BookDTO as prop
const props = defineProps( {
  bookReview: {
    type: Object as PropType<BookReviewDTO>,
    required: true
  }
})

const bookReview = computed(() => {
  return props.bookReview
})

const userImage = computed(() => {
  return `customers/${props.bookReview.user.image}`
})
</script>

<style scoped lang="scss">
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.bg-whitesmoke {
  background-color: whitesmoke;
}
</style>
