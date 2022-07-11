<template>
  <div class="q-pa-xl row justify-center items-center">
    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-pt-xl q-pb-xl bg-primary-light col"
      style="border-radius: 15px; max-width: 1200px"
    >
      <div class="row justify-center items-center">
        <q-img
          class="q-mb-xl"
          :src="logo_url"
          spinner-color="white"
          style="max-width: 150px"
          :fit="'contain'"
        />
      </div>

      <div class="q-gutter-lg row justify-center">
        <div class="col-4">
          <p> Billing info </p>

          <q-input
            filled
            v-model="address.street"
            label="Street *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Your address street can\'t be empty!']"
          />

          <q-input
            filled
            v-model="address.number"
            label="Street Number *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Your address number can\'t be empty!']"
          />

          <q-input
            filled
            v-model="address.city"
            label="City *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'The city where you live can\'t be empty!']"
          />

          <q-input
            filled
            v-model="address.postCode"
            label="Post Code *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'The post code can\'t be empty!']"
          />
        </div>

        <div class="col-4">
          <p> Personal info </p>

          <q-input
            filled
            v-model="user.username"
            label="Username *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Your username can\'t be empty!']"
          />

          <q-input
            v-model="user.password"
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

          <q-input
            v-model="confirmPassword"
            label="Confirm Password *"
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

          <q-input
            filled
            v-model="user.fullname"
            label="Full Name *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Your name can\'t be empty!']"
          />

          <q-input
            filled
            v-model="user.email"
            label="Email *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Your email can\'t be empty!']"
          />

          <div>
            <q-input filled v-model="birthDate" label="Birthday *" mask="date" :rules="['date']">
              <template v-slot:append>
                <q-icon name="event" class="cursor-pointer">
                  <q-popup-proxy cover transition-show="scale" transition-hide="scale">
                    <q-date v-model="birthDate">
                      <div class="row items-center justify-end">
                        <q-btn v-close-popup label="Close" color="primary" flat />
                      </div>
                    </q-date>
                  </q-popup-proxy>
                </q-icon>
              </template>
            </q-input>
          </div>

          <q-input
            filled
            type="tel"
            v-model="user.phoneNumber"
            label="Phone Number *"
            lazy-rules
            :rules="[val => val && val.length === 10 || 'Your phone number must be exactly 10 digits!']"
          />

          <q-input
            filled
            v-model="user.image"
            label="Profile Image *"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Your profile image can\'t be empty!']"
          />

        </div>

        <div class="q-mt-lg col-12 row justify-center items-center">
          <div>
            <q-btn label="Register" type="submit" color="primary"/>
            <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
          </div>
        </div>

      </div>
    </q-form>
  </div>
</template>

<script setup lang="ts">
import {computed, reactive, ref} from 'vue';
import {AddressDTO} from 'src/types/AddressDTO';
import { useRouter } from 'vue-router';
import {useAuthStore} from 'stores/auth';
import {UserRegisterDTO} from 'src/types/Users/UserRegisterDTO';
import { useQuasar } from 'quasar'

// User Info
const birthDate = ref('')
const confirmPassword = ref('')
const address = reactive<AddressDTO>({} as AddressDTO)
const user = reactive<UserRegisterDTO>({} as UserRegisterDTO)

const formattedBirthdate = computed(() => {
  return `${birthDate.value.replaceAll('/', '-')}T00:00:00.828Z`
})

// Design stuff
const logo_url = ref('logo.png')
const isPwd = ref(true)

// Utilities
const router = useRouter()
const $q = useQuasar()
const authStore = useAuthStore()

async function register(userToRegister: UserRegisterDTO) {
  userToRegister.birthDate = formattedBirthdate.value
  userToRegister.role = 'Customer'
  userToRegister.address = address

  console.log(`Register form submitted with creds:
        username: ${ userToRegister.username }
        password: ${ userToRegister.password }
        \n ${JSON.stringify(userToRegister)}`)

  if (user.password == confirmPassword.value) {
    await authStore.register(userToRegister).then(() => {
      console.log('Register successful from inside register function: ' + authStore.getRegisterSuccessful)
    }).catch(error => {
      console.log('An error occurred during customer register')
      console.log(error)
    })
  }
  else {
    $q.notify({
      type: 'negative',
      message: 'Passwords don\'t match'
    })
  }
}

function onSubmit() {
  register(user).then(() => {
    console.log('Register successful after register function: ' + authStore.getRegisterSuccessful)
    if (authStore.getRegisterSuccessful) {
      $q.notify({
        type: 'positive',
        message: 'Successfully registered! Redirecting to login page in 3 seconds...'
      })

      // Reset the register state
      authStore.registerSuccessful = false

      // Get back on the login page after 3 seconds
      setTimeout(() => {
        router.push('/auth')
      }, 3000)
    }
    else {
      $q.notify({
        type: 'negative',
        message: 'Registration failed. Please try again'
      })
    }
  })
}

function onReset() {
  user.username = ''
  user.password = ''
  confirmPassword.value = ''
  user.fullname = ''
  user.email = ''
  user.address = {} as AddressDTO
  birthDate.value = ''
  user.phoneNumber = ''
  user.image = ''
}

</script>

<style scoped>

</style>
