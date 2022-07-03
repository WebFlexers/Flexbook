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
        v-model="username"
        label="Username *"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Your username can\'t be empty!']"
      />
      <q-input
        v-model="password"
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
    </q-form>

  </div>
</template>

<script>
import { useQuasar } from 'quasar'
import { ref } from 'vue'

export default {
  setup () {
    const $q = useQuasar()

    const username = ref('')
    const password = ref('')
    let authToken = ''

    return {
      username,
      password,
      isPwd: ref(true),
      logo_url: ref('logo.png'),

      onSubmit () {
        console.log(`Login form submitted with creds:
        username: ${username.value}
        password: ${password.value}`)
      },

      onReset () {
        username.value = null
        password.value = null
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
