<template>
  <q-card class="bookContainer row q-pa-md">
    <q-img :src="bookImage" alt="book_image" fit="scale-down" style="max-height: 200px"/>

    <q-card-section>
      <div class="text-h6"> {{ book.title }} </div>
      <div class="text-subtitle2"> by {{ book.author.fullname }}</div>
    </q-card-section>

    <q-card-section class="bookDescription q-pt-none">
      <p>
        {{ book.description }}
      </p>
    </q-card-section>

    <q-card-actions>
      <div class="self-center text-center">
        <q-btn class="q-mt-md" color="primary" align="center"> Add to Cart </q-btn>
      </div>
    </q-card-actions>
  </q-card>
</template>

<script setup lang="ts">
import {computed, defineProps, PropType} from 'vue';
import { BookDTO } from 'src/types/BookDTO';

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
</script>

<style scoped lang="scss">
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.bookContainer {
  width: 290px;
  height: 530px;
}

.bookDescription {
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
