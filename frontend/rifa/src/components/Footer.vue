<template>
  <v-footer class="bg-teal-darken-1" height="auto">
    <v-card
      width="100%"
      flat
      tile
      class="bg-teal-darken-4 white--text text-xs-center"
    >
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
      <v-card-text>
        <v-row>
          <v-col
            cols="12"
            width="100%"
            class="white--text pt-0 d-flex justify-center align-center"
          >
          </v-col>
        </v-row>
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
