<template>
  <div class="q-pa-xl row justify-center items-center">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-pa-lg q-gutter-sm bg-primary-light col-12 text-center self-center"
      style="border-radius: 15px; max-width: 600px"
    >
      <q-img
        class="q-mb-xl"
        :src="logo_url"
        spinner-color="white"
        style="max-width: 150px"
        :fit="'contain'"
      />

      <q-input
        filled
        v-model="loginCredentials.username"
        label="Username *"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Your username can\'t be empty!']"
      />
      <q-input
        v-model="loginCredentials.password"
        label="Password *"
        filled :type="isPwd ? 'password' : 'text'"
        :rules="[ val => val && val.length > 0 || 'Your password can\'t be empty!']">
        <template v-slot:append>
          <q-icon
            :name="isPwd ? 'visibility_off' : 'visibility'"
            class="cursor-pointer"
            @click="isPwd = !isPwd"
          />
        </template>
      </q-input>

      <div>
        <q-btn label="Login" type="submit" color="primary"/>
        <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
      </div>

      <div class="q-ma-lg">
        <p> Don't have an account yet? <router-link to="/register"> Click here </router-link> to create a new one</p>
      </div>
    </q-form>

  </div>
</template>

<script lang="ts">
import { useAuthStore } from 'src/stores/auth';
import { useQuasar } from 'quasar'
import { reactive, ref } from 'vue'
import { Login } from 'src/types/Auth/Login';
import { useRouter } from 'vue-router';

export default {
  setup() {
    const authStore = useAuthStore()
    const router = useRouter();
    const loginCredentials = reactive<Login>({} as Login)
    const $q = useQuasar()

    function triggerNotFoundMessage () {
      $q.notify({
        type: 'negative',
        message: 'User not found'
      })
    }

    async function login() {
      console.log(`Login form submitted with creds:
        username: ${ loginCredentials.username }
        password: ${ loginCredentials.password }`)

      authStore.login(loginCredentials).then(() => {
        if (localStorage.getItem('accessToken')) {
          router.push('/')
        }
        else {
          triggerNotFoundMessage()
        }
      })
    }

    return {
      isPwd: ref(true),
      logo_url: ref('logo.png'),
      loginCredentials,

      onSubmit () {
        login()
      },

      onReset () {
        loginCredentials.username = ''
        loginCredentials.password = ''
      }
    }
  }
}
</script>

<style lang="scss">
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

.bg-primary-light {
  background-color: $primary-light;
}
</style>
