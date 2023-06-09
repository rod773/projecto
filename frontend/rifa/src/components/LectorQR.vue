<template>
  <v-dialog v-model="lectorqr">
    <v-container class="d-flex justify-center" width="100%">
      <v-card width="500" color="teal" theme="dark">
        <v-card-title>
          <div class="text-h5 text-center font-weight-light">Leer QR</div>
        </v-card-title>
        <v-card-text> </v-card-text>
        <v-card-actions>
          <v-divider></v-divider>

          <div class="pa-4 text-end">
            <v-btn
              class="bg-secondary"
              min-width="92"
              rounded
              variant="outlined"
              @click="lectorqr = false"
            >
              Close
            </v-btn>
          </div>
        </v-card-actions>
      </v-card>
    </v-container>
  </v-dialog>
</template>

<script setup lang="ts">
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";

const appstore = useAppStore();

const { lectorqr } = storeToRefs(appstore);
</script>

<style scoped lang="scss"></style>
