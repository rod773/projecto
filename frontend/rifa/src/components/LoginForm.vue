<template>
  <v-dialog v-model="dialog">
    <v-container class="d-flex justify-center" width="100%">
      <v-card width="500" color="teal" theme="dark">
        <v-card-title>
          <div class="text-h5 text-center font-weight-light">Ingresar</div>
        </v-card-title>

        <v-card-text>
          <v-form>
            <v-text-field
              label="Indroduce el email"
              v-model="email"
              name="email"
              prepend-inner-icon="mdi-email"
              type="email"
              class="rounded-0"
              outlined
              clearable
            ></v-text-field>

            <v-text-field
              label="Introduce una clave"
              v-model="password"
              name="password"
              prepend-inner-icon="mdi-lock"
              type="password"
              class="rounded-0"
              outlined
              clearable
            ></v-text-field>
            <v-divider></v-divider>

            <div class="pa-4 text-center">
              <!-- <v-btn light @click="autenticar()">auntenticar</v-btn> -->
              <v-btn
                min-height="50"
                rounded
                variant="outlined"
                class="bg-cyan"
                width="50%"
                @click="autenticar(email, password)"
                >Ingresar</v-btn
              >
            </div>
          </v-form>
        </v-card-text>
        <v-card-actions class="ml-6 mr-6 text-center">
          <v-divider></v-divider>

          <div class="pa-4 text-end">
            <v-btn
              class="bg-secondary"
              min-width="92"
              rounded
              variant="outlined"
              @click="dialog = false"
            >
              Close
            </v-btn>
          </div>
        </v-card-actions>
      </v-card>
    </v-container>
  </v-dialog>
  >
</template>

<script setup lang="ts">
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";
import { ref } from "vue";

const appstore = useAppStore();

const { dialog } = storeToRefs(appstore);

//*************** */

const email = ref("");
const password = ref("");

//*********** */

const autenticar = (email: string, password: string) => {
  appstore.autenticar(email, password);
};

//************* */
</script>

<style scoped lang="scss"></style>
