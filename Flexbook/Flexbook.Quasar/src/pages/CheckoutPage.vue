<template>
  <div class="row justify-center q-mt-xl">
    <div class="q-my-xl" style="max-width: 1000px">

      <q-stepper
        class="bg-primary-light"
        v-model="stepperStep"
        ref="stepper"
        color="primary"
        animated
      >

        <q-step
          :name="1"
          title="Shopping cart"
          icon="shopping_cart_checkout"
          :done="stepperStep > 1"
        >
          <!-- Shopping cart -->
          <div v-if="authStore.loggedIn">
            <q-list>
              <q-item class="row flex-center q-pt-lg" v-if="shoppingCartStore.getShoppingCartItems.length <= 0">
                <p style="font-weight: bold"> Your cart is empty! </p>
              </q-item>
              <q-item v-for="(cartItem) in shoppingCart" :key="cartItem" class="row justify-center">
                <BookInCart  :shoppingCartBook="cartItem"/>
              </q-item>
              <div v-if="shoppingCartStore.getShoppingCartItems.length >= 1">
                <q-item class="row flex-center q-pt-lg">
                  <p style="font-size: 1.3em; font-weight: 500"> Total Price: {{ totalPrice }}€ </p>
                </q-item>
              </div>
            </q-list>
          </div>
        </q-step>

        <q-step
          :name="2"
          title="Payment method"
          icon="payments"
          :done="stepperStep > 2"
        >
          <div class="row justify-center q-mb-xl">
            <div>
              <h5> Choose your payment method </h5>
              <q-select v-model="order.paymentMethod" :options="paymentMethods" label="Payment Method" />
            </div>
          </div>
        </q-step>

        <q-step
          :name="3"
          title="Checkout"
          icon="shopping_cart_checkout"
        >
          <h5> Everything is ready. Press the button below to checkout! </h5>
          <q-item class="row flex-center q-pb-md">
            <q-btn label="Submit Order" color="primary" @click="submitOrder"/>
          </q-item>
        </q-step>

        <template v-slot:navigation>
          <q-stepper-navigation>
            <div v-if="shoppingCartStore.getShoppingCartItems.length >= 1">
              <q-btn @click="$refs.stepper.next()" color="primary" :label="stepperStep === 3 ? 'Finish' : 'Continue'" />
              <q-btn v-if="stepperStep > 1" flat color="primary" @click="$refs.stepper.previous()" label="Back" class="q-ml-sm" />
            </div>

<!--            Go back to home page button if the shopping cart is empty-->
            <div v-if="shoppingCartStore.getShoppingCartItems.length <= 0" class="row justify-center">
              <q-btn style="max-height: 50px" color="primary" @click="returnToHome"> Back to home </q-btn>
            </div>
          </q-stepper-navigation>
        </template>
      </q-stepper>

    </div>
  </div>
</template>

<script setup lang="ts">
import {computed, ref} from 'vue';
import {useAuthStore} from 'stores/auth';
import {useShoppingCartStore} from 'stores/shopping-cart';
import {useQuasar} from 'quasar';
import {useRouter} from 'vue-router';
import BookInCart from 'components/BookInCart.vue';
import {OrderDTO} from 'src/types/Orders/OrderDTO';
import {OrderItemDTO} from 'src/types/Orders/OrderItemDTO';
import {OrderService} from 'src/services/OrderService';

const stepperStep = ref(1)

const $q = useQuasar()
const router = useRouter()

const order = ref<OrderDTO>({} as OrderDTO)
let orderItems: OrderItemDTO[] = []
const paymentMethods = ['COD', 'Debit/Credit Card', 'Paypal']

const authStore = useAuthStore()
const shoppingCartStore = useShoppingCartStore()

const shoppingCart = computed(() => {
  console.log(shoppingCartStore.getShoppingCartItems.length)
  return shoppingCartStore.getShoppingCartItems
})

const totalPrice = computed(() => {
  return shoppingCartStore.calculateTotalPrice()
})

// Return to home page if not logged in
if (!authStore.loggedIn) {
  returnToHome()
}

// Return to home page
function returnToHome() {
  router.push('/')
}

// Create an order and push it to the api
function submitOrder() {
  order.value.orderItemsList = shoppingCartStore.getItemsAsOrderItemDTOs
  order.value.customerId = authStore.user.id

  const orderService = new OrderService()
  orderService.createOrder(order.value).then(() => {
    shoppingCartStore.clearCart()

    $q.notify({
      type: 'positive',
      message: 'Successfully placed order! Redirecting to home page in 3 seconds',
      timeout: 3000
    })

    // Get back on the home page after 3 seconds
    setTimeout(() => {
      returnToHome()
    }, 3000)
  }).catch((error) => {
    console.error(error)
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
