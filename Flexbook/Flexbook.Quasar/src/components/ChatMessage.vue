<template>
  <q-space v-if="isUserTheAuthor"/>
  <div style="width: 100%; max-width: 400px" class="row justify-start">
    <q-chat-message
      class="col-10"
      :bg-color="messageBgColor"
      :name="username"
      :avatar="userImage"
      :text="[messageContent]"
      :sent="isUserTheAuthor"
    />
  </div>
</template>

<script setup lang="ts">
// Get a BookDTO as prop
import {computed, defineProps, PropType, ref} from 'vue';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';
import {CommentDTO} from 'src/types/Forum/CommentDTO';

const props = defineProps( {
  author: {
    type: Object as PropType<AuthorDTO>,
    required: true
  },
  comment: {
    type: Object as PropType<CommentDTO>,
    required: true
  }
})
const likeClicked = ref(false)

const username = computed(() => {
  return props.comment.user.username
})

const messageContent = computed(() => {
  return props.comment.content
})

const isUserTheAuthor = computed(() => {
  return props.author.id == props.comment.user.id;
})

const userImage = computed(() => {
  switch (props.comment.user.role) {
    case 'Customer':
      return `customers/${props.comment.user.image}`
    case 'Author':
      return `authors/${props.author.image}`
    default:
      return ''
  }
})

const messageBgColor = computed(() => {
  if (isUserTheAuthor.value) {
    return 'primary'
  }
  else {
    return 'white'
  }
})
</script>

<style scoped>

</style>
