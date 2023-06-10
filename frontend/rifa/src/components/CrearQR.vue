<template>
  <v-dialog v-model="crearqr">
    <v-container class="d-flex justify-center" width="100%">
      <v-card width="500" color="teal" theme="dark">
        <v-card-title>
          <div class="text-h5 text-center font-weight-light">
            Crear Imagen QR
          </div>
        </v-card-title>
        <v-card-text id="codigo">
          <v-text-field v-model="urlText" clearable> </v-text-field>
          <v-div class="d-flex justify-center">
            <vue-qrious
              v-if="urlText"
              :value="urlText"
              @change="onDataChange"
              :size="300"
            >
            </vue-qrious
          ></v-div>
        </v-card-text>

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
                Guardar
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
import VueQrious from "vue-qrious";
import vueQr from "vue-qr/src/packages/vue-qr.vue";

const appstore = useAppStore();

const { crearqr } = storeToRefs(appstore);

//************************* */
const imagenqr = ref();

const urlText = ref("");

const codigo = ref();

//************************* */
const handleClickCrearQR = () => {
  codigo.value = document.querySelector("#codigo img");
  console.dir(codigo.value.src);
  const enlace = document.createElement("a");
  enlace.href = codigo.value.src;
  enlace.download = "Código QR generado.png";
  enlace.click();
};

//************************ */

const onDataChange = () => {
  console.log(urlText.value);
};
//************************ */
</script>

<style scoped></style>
