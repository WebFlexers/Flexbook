<template>
  <q-layout view="lHh Lpr lFf">
    <q-header class="bg-primary-light" elevated>
      <div class="row q-pa-sm">
       <q-img
          :src="logo_url"
          spinner-color="white"
          style="max-width: 100px"
          :fit="'contain'"
        />

        <q-input class="q-mx-lg col" v-model="search" label="Search Books" style="min-width: 80px;">
          <q-icon class="q-mt-md" name="search" size="26px"/>
        </q-input>

        <q-space />

        <div class="self-center q-gutter-md q-mr-md">
          <q-btn v-if="!loggedIn" color="primary" label="Login/Register" @click="goToLoginPage"/>

          <q-btn v-if="loggedIn" round>
            <q-avatar size="72px">
              <img :src="`${profileImage}`" alt="customer_image">
            </q-avatar>
            <q-menu>
              <div class="row no-wrap q-pa-md">
                <div class="column">
                  <div class="text-h6 q-mb-md">Settings</div>
                </div>

                <q-separator vertical inset class="q-mx-lg" />

                <div class="column items-center">
                  <q-avatar size="72px">
                    <img :src="`${profileImage}`" alt="user_image">
                  </q-avatar>

                  <div class="text-subtitle1 q-mt-md q-mb-xs"> {{ authenticatedUser.fullname }} </div>

                  <q-btn
                    color="primary"
                    label="Logout"
                    push
                    size="sm"
                    @click="logout"
                    v-close-popup
                  />
                </div>
              </div>
            </q-menu>
          </q-btn>

          <q-btn v-if="loggedIn" color="primary" label="Shopping Cart" />

        </div>

      </div>

      <q-tabs class="row route-tabs">
        <q-route-tab class="col" to="/" label="Home" />
        <q-route-tab class="col" to="/literature_books" label="Literature" />
        <q-route-tab class="col" to="/education_books" label="Education" />
        <q-route-tab class="col" to="/children_books" label="Children's Books" />
        <q-route-tab class="col" to="/history_books" label="History" />
        <q-route-tab class="col" to="/science_books" label="Sciences" />
      </q-tabs>
    </q-header>

    <q-page-container>
      <router-view>
      </router-view>
    </q-page-container>

  </q-layout>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
import { useRouter } from 'vue-router';
import { useAuthStore } from 'src/stores/auth';

export default defineComponent({
  name: 'MainLayout',

  setup() {
    const router = useRouter();
    const authStore = useAuthStore();
    const loggedIn = computed(() => {
      return authStore.getLoggedIn;
    });

    const authenticatedUser = computed(() => {
      return authStore.getUser;
    });

    const profileImage = computed(() => {
      if (authenticatedUser.value) {
        return `${authenticatedUser.value.role.toLowerCase()}s/${authenticatedUser.value.image}`
      }

      return undefined
    });

    function logout() {
      authStore.logout();
      goToLoginPage();
    }

    function goToLoginPage() {
      router.push('/auth')
    }

    return {
      search: ref(''),
      logo_url: ref('logo.png'),
      loggedIn,
      authenticatedUser,
      profileImage,
      logout,
      goToLoginPage
    }
  }
});
</script>

<style lang="scss">
  @import "src/css/app.scss";
  @import "src/css/quasar.variables.scss";

  .bg-primary-light {
    background-color: $primary-light;
  }

  .route-tabs {
    color: $primary;
    background-color: $primary-light;
  }
</style>
