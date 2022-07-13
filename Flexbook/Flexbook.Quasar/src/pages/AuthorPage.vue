<template>
  <div class="row justify-center items-center q-mb-xl">
    <div class="bg-primary-light q-mt-xl q-pb-xl q-px-xl"
         style="max-width: 1200px; min-width: 800px; border-radius: 15px;">

      <div class="row justify-center">
        <h4 style="font-weight: 500"> {{ author.fullname }} </h4>
      </div>

      <div class="row justify-center">
        <q-avatar size="200px" class="row justify-center">
          <q-img :src="authorImage" alt="author_image"/>
        </q-avatar>
      </div>

<!--      Author Description-->
      <div class="row justify-center">
        <h5> Description </h5>
      </div>

      <div class="row justify-center">
        <p> {{ author.description }} </p>
      </div>

      <!--      Forum-->
      <div v-if="comments.length >= 1">
        <div class="row justify-center">
          <h5> Forum </h5>
        </div>

        <!--      Display comments and questions-->
        <div v-for="(comment) in comments" :key="comment" class="row q-ml-xl">
          <ChatMessage class="q-ml-xl" :author="author" :comment="comment"/>
        </div>
      </div>

      <div v-if="authStore.getLoggedIn">
        <div class="row justify-center q-mt-xl">
          <p class="text-semi-bold q-mt-lg" style="font-size: 1.7em"> Ask a question or leave a comment below: </p>
        </div>

        <div class="row justify-center">
          <q-editor style="max-width: 400px; min-width: 400px" v-model="userComment.content" min-height="5rem" />
        </div>

        <div class="row justify-center">
          <q-btn color="primary q-mt-md" @click="submitComment"> Submit </q-btn>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import {computed, ref} from 'vue';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';
import {useCurrentAuthorStore} from 'stores/current-author';
import {useRoute, useRouter} from 'vue-router';
import AuthorService from 'src/services/AuthorService';
import {CommentDTO} from 'src/types/Forum/CommentDTO';
import {ForumService} from 'src/services/ForumService';
import ChatMessage from 'components/ChatMessage.vue';
import {CreateCommentDTO} from 'src/types/Forum/CreateCommentDTO';
import {useAuthStore} from 'stores/auth';
import {useQuasar} from 'quasar';

const $q = useQuasar()

const author = ref({} as AuthorDTO)
const comments = ref<CommentDTO[]>([])

const route = useRoute()
const router = useRouter()
const currentAuthorStore = useCurrentAuthorStore()

// Get the author from the store if it exists
if (currentAuthorStore.author.fullname) {
  author.value = currentAuthorStore.getAuthor
  fetchAllComments()
  console.log('Authors full name is ' + author.value.fullname)
}
else {
  // Try to get the author from the api using the page url
  const authorService = new AuthorService()
  authorService.getAuthorByName(route.params.fullname.toString()).then((foundAuthor) => {
    if (foundAuthor) {
      author.value = foundAuthor
      fetchAllComments()
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

// Author image
const authorImage = computed(() => {
  if (author.value) {
    return `authors/${author.value.image}`
  }

  return undefined
});

function isUserTheAuthor(comment: CommentDTO) {
  return author.value.id == comment.user.id;
}

// Get all comments-questions from author id
function fetchAllComments() {
  const forumService = new ForumService()
  forumService.getAllCommentsByAuthorId(author.value.id).then((fetchedComments) => {
    comments.value = fetchedComments
  }).catch((error) => {
    console.error(error)
  })
}

const userComment = ref<CreateCommentDTO>({} as CreateCommentDTO)
userComment.value.content = ''
const authStore = useAuthStore()

function submitComment() {
  if (userComment.value.content === '') {
    $q.notify({
      type: 'negative',
      message: 'Can\'t write an empty comment!',
      timeout: 1000
    })
    return
  }

  userComment.value.userId = authStore.user.id
  userComment.value.authorHostId = author.value.id

  console.log('CreateCommentDTO is ')
  console.log(userComment.value)

  const forumService = new ForumService()
  forumService.createComment(userComment.value).then(() => {
    $q.notify({
      type: 'positive',
      message: 'Successfully uploaded comment!',
      timeout: 1000
    })

    userComment.value.content = ''
    fetchAllComments()

  }).catch((error) => {
    console.log(error)
    $q.notify({
      type: 'negative',
      message: 'Failed to upload comment...',
      timeout: 1000
    })
  })
}

</script>

<style scoped lang="scss">
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.bg-primary-light {
  background-color: $primary-light;
}
</style>
