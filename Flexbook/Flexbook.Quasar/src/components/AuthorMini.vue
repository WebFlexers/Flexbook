<template>
  <div class="q-px-lg q-pt-lg sectionWidth bg-whitesmoke cursor-pointer" style="border-radius: 20px"
       @click="goToAuthorPage">
    <div class="row justify-start q-gutter-md">
      <div class="col-4">
        <q-avatar size="100px">
          <q-img :src="authorImage" alt="author_image"/>
        </q-avatar>
      </div>
      <div class="col q-ml-md q-pa-md">
        <p style="font-weight: 500"> {{ author.fullname }} </p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import {computed, defineProps, PropType} from 'vue';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';
import {useRouter} from 'vue-router';
import {useCurrentAuthorStore} from 'stores/current-author';

// Get an AuthorDTO as prop
const props = defineProps( {
  author: {
    type: Object as PropType<AuthorDTO>,
    required: true
  }
})

const authorImage = computed(() => {
  if (props.author) {
    return `authors/${props.author.image}`
  }

  return undefined
});

const router = useRouter()
const currentAuthorStore = useCurrentAuthorStore()
function goToAuthorPage() {
  currentAuthorStore.author = props.author
  router.push(`/author/${props.author.fullname.replaceAll(' ', '-')}`)
}
</script>

<style lang="scss" scoped>
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.sectionWidth {
  min-width: 345px;
  max-width: 345px;
  height: 150px;
}

.sectionWidth:hover {
  border-style: solid;
  border-color: $primary;
  border-width: 1px;
}
</style>
