<template>
  <router-view v-slot="{ Component, route }">
    <!-- 2️⃣ -->
    <transition name="fade" mode="out-in">
      <!-- 3️⃣ -->
      <component :is="Component" :key="route.path" />
    </transition>
  </router-view>
</template>

<script lang="ts">
import {defineComponent} from 'vue';


export default defineComponent({
  name: 'App'
});
</script>

<style lang="css">
.fade-enter-active,
.fade-leave-active {
  transition: opacity .2s, transform .2s;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}

</style>
