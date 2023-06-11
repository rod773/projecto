<template>
  <v-footer class="bg-teal-darken-1" height="auto">
    <v-card flat tile class="bg-teal-darken-4 white--text text-xs-center">
      <v-card-text class="d-flex justify-center">
        <v-btn
          opacity="0.8"
          v-for="icon in icons"
          :key="icon"
          class="mx-3 white--text bg-green"
          icon
        >
          <v-icon size="24px">{{ icon }}</v-icon>
        </v-btn>
      </v-card-text>

      <v-card-text class="white--text pt-0">
        Phasellus feugiat arcu sapien, et iaculis ipsum elementum sit amet.
        Mauris cursus commodo interdum. Praesent ut risus eget metus luctus
        accumsan id ultrices nunc. Sed at orci sed massa consectetur dignissim a
        sit amet dui. Duis commodo vitae velit et faucibus. Morbi vehicula
        lacinia malesuada. Nulla placerat augue vel ipsum ultrices, cursus
        iaculis dui sollicitudin. Vestibulum eu ipsum vel diam elementum tempor
        vel ut orci. Orci varius natoque penatibus et magnis dis parturient
        montes, nascetur ridiculus mus.
      </v-card-text>

      <v-divider></v-divider>

      <v-card-text class="white--text">
        &copy;2023 — <span class="text-h7 text-light">Rodrigo</span>
      </v-card-text>
    </v-card>
  </v-footer>
</template>

<script setup lang="ts">
import { ref } from "vue";

const icons = ref([
  "mdi-facebook",
  "mdi-twitter",
  "mdi-google-plus",
  "mdi-linkedin",
  "mdi-instagram",
]);
</script>

<style scoped></style>
