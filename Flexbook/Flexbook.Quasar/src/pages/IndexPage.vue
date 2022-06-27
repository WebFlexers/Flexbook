<template>
  <div class="row q-ma-lg">
    <SalesComponent class="col-2"></SalesComponent>
  </div>

</template>

<script lang="ts">
import { defineComponent } from 'vue';
import SalesComponent from 'components/SalesComponent.vue';

export default defineComponent({
  name: 'IndexPage',
  components: {SalesComponent},
});
</script>
