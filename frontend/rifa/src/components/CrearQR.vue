<template>
  <v-dialog v-model="crearqr">
    <v-container class="d-flex justify-center" width="100%">
      <v-card width="500" color="teal" theme="dark">
        <v-card-title>
          <div class="text-h5 text-center font-weight-light">
            Crear Imagen QR
          </div>
        </v-card-title>
        <v-card-text> </v-card-text>

        <v-divider></v-divider>
        <v-card-actions>
          <v-row>
            <v-col cols="6" class="d-flex justify-center align-center">
              <v-btn
                class="bg-success"
                min-width="92"
                rounded
                variant="outlined"
                @click="handleClickCrearQR"
              >
                Crear QR
              </v-btn>
            </v-col>
            <v-col cols="6" class="d-flex justify-center align-center">
              <v-btn
                class="bg-secondary"
                min-width="92"
                rounded
                variant="outlined"
                @click="crearqr = false"
              >
                Close
              </v-btn>
            </v-col>
          </v-row>
        </v-card-actions>
      </v-card>
    </v-container>
  </v-dialog>
</template>

<script setup lang="ts">
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";
import { ref } from "vue";

const appstore = useAppStore();

const { crearqr } = storeToRefs(appstore);

//************************* */

//************************* */
const handleClickCrearQR = ref();

//************************ */

const onDataChange = () => {};
//************************ */
</script>

<style scoped></style>
