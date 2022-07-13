<template>
  <q-layout view="lHh Lpr lFf">
    <q-header class="bg-primary-light" elevated>
      <div class="row q-pa-sm q-gutter-md">
       <q-img
          :src="logo_url"
          spinner-color="white"
          style="max-width: 100px"
          :fit="'contain'"
        />

        <q-input class="q-mx-lg col" v-model="searchStore.userSearch" label="Search Books" style="min-width: 80px;">
          <q-icon class="q-mt-md" name="search" size="26px"/>
        </q-input>

        <q-select class="col-1" v-model="searchStore.searchType" :options="searchOptions" label="Search By" />

        <div class="self-center q-gutter-md q-mr-md">
          <q-btn v-if="!loggedIn" color="primary" label="Login/Register" @click="goToLoginPage"/>

          <q-btn v-if="loggedIn" round>
            <q-avatar size="72px">
              <img :src="`${profileImage}`" alt="customer_image">
            </q-avatar>
            <q-menu>
              <div class="row no-wrap q-pa-md">
                <div class="column items-center">
                  <div class="text-bold q-mb-xs" style="font-size: 1.3em"> {{ authenticatedUser.fullname }} </div>
                    <q-btn
                      v-if="authStore.user.role === 'Author'"
                      class="q-mb-sm"
                      color="primary"
                      label="Profile"
                      push
                      size="md"
                      v-close-popup
                    />

                    <q-btn
                      color="primary"
                      label="Logout"
                      push
                      size="md"
                      @click="logout"
                      v-close-popup
                    />
                </div>
              </div>
            </q-menu>
          </q-btn>

<!--          Shopping Cart-->
          <q-btn-dropdown v-if="loggedIn && authStore.user.role === 'Customer'"
                          align="around" icon="shopping_cart" color="primary" label="Shopping Cart" >
            <q-list>
              <q-item class="row flex-center q-pt-lg" v-if="shoppingCartStore.getShoppingCartItems.length <= 0">
                <p style="font-weight: bold"> Your cart is empty! </p>
              </q-item>
              <q-item v-for="(cartItem) in shoppingCart" :key="cartItem">
                <BookInCart  :shoppingCartBook="cartItem"/>
              </q-item>
              <div v-if="shoppingCartStore.getShoppingCartItems.length >= 1">
                <q-item class="row flex-center q-pt-lg">
                  <p style="font-size: 1.3em; font-weight: 500"> Total Price: {{ totalPrice }}€ </p>
                </q-item>
                <q-item class="row flex-center q-pb-md">
                  <q-btn label="Checkout" color="primary" @click="goToCheckout"/>
                </q-item>
              </div>
            </q-list>
          </q-btn-dropdown>

          <q-badge v-if="shoppingCartStore.getShoppingCartItems.length >= 1"
            rounded color="red"> {{ shoppingCartStore.getShoppingCartItems.length }}
          </q-badge>



        </div>

      </div>

      <q-tabs class="row route-tabs">
        <q-route-tab class="col-4 col-md" to="/" label="Home" />
        <q-route-tab class="col-4 col-md" to="/literature_books" label="Literature" />
        <q-route-tab class="col-4 col-md" to="/education_books" label="Education" />
        <q-route-tab class="col-4 col-md" to="/children_books" label="Children's Books" />
        <q-route-tab class="col-4 col-md" to="/history_books" label="History" />
        <q-route-tab class="col-4 col-md" to="/science_books" label="Sciences" />
      </q-tabs>
    </q-header>

    <q-page-container>
      <router-view>
      </router-view>
    </q-page-container>

  </q-layout>
</template>

<script lang="ts" setup>
import { ref, computed } from 'vue';
import { useRouter } from 'vue-router';
import { useAuthStore } from 'src/stores/auth';
import { useSearchStore } from 'stores/search';
import {useShoppingCartStore} from 'stores/shopping-cart';
import BookInCart from 'components/BookInCart.vue';

const searchStore = useSearchStore()
const logo_url = ref('logo.png')

const searchOptions = ref([
  'Title', 'Publisher', 'Author', 'Language'
])

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
  shoppingCartStore.clearCart()
  authStore.logout()
  goToLoginPage()
}

function goToLoginPage() {
  router.push('/auth')
}

function goToCheckout() {
  router.push('/checkout')
}

const shoppingCartStore = useShoppingCartStore()
const shoppingCart = computed(() => {
  return shoppingCartStore.shoppingCartItems
})
const totalPrice = computed(() => {
  return shoppingCartStore.calculateTotalPrice()
})
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
