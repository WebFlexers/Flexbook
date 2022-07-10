<template>
  <q-card class="bookCard q-pa-md q-pt-lg">
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

    <q-card-section class="row q-ml-md q-mb-md cursor-text absolute-bottom" style="color: grey; ">
        <q-btn style="max-height: 40px" color="primary"> Add to Cart </q-btn>
        <p class="q-ml-xl q-mt-sm">
          Price: <span style="color: black; font-weight: bold"> {{ book.startingPrice }}€ </span>
        </p>
    </q-card-section>
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

function goToBookPage() {
  alert('To the moon')
}
</script>

<style scoped lang="scss">
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.bookCard {
  min-width: 340px;
  max-width: 340px;
  height: 530px;
}

.bookCard:hover {
  border-style: solid;
  border-color: $primary;
  border-width: 1px;
}

.bookDescription {
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
