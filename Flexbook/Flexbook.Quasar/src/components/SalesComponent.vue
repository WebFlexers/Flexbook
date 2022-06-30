<template>
  <div class="col">
    <div class="absolute q-mt-sm">
      <q-chip size="lg" icon="local_offer" color="secondary" text-color="white">
        Sales
      </q-chip>
    </div>

    <div class="bookSection">
      <p> Hello world </p>

      <div class="text-center">
        <q-btn class="q-px-lg" color="primary"> More </q-btn>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'SalesComponent'
}
</script>

<style lang="scss" scoped>
@import "src/css/app.scss";
@import "src/css/quasar.variables.scss";

  .bookSection {
    background-color: $primary-light;
    padding: 20px 10px 10px 10px;
    margin-top: 40px;
    margin-left: 4px;
  }
</style>
