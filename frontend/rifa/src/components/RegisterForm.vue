<template>
  <v-dialog v-model="dialogreg">
    <v-row justify="center">
      <v-card color="teal" theme="dark" width="600">
        <v-card-title>
          <div class="text-h5 text-center font-weight-light">Registro</div>
        </v-card-title>

        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12">
                <v-text-field
                  v-model="nombres"
                  label="Nombres*"
                  required
                ></v-text-field>
              </v-col>

              <v-col cols="12">
                <v-text-field
                  v-model="apellidos"
                  label="Apellidos*"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="email"
                  label="Email*"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  label="Clave*"
                  v-model="clave"
                  type="password"
                  required
                ></v-text-field>
              </v-col>
            </v-row>
          </v-container>
          <div class="text-h7 text-center text-red">*campo requerido</div>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <div class="pa-4 text-end">
            <v-btn
              class="bg-secondary"
              min-width="92"
              rounded
              variant="outlined"
              @click="dialogreg = false"
            >
              Close
            </v-btn>
          </div>
          <div class="pa-4 text-end">
            <v-btn
              class="bg-success"
              min-width="92"
              rounded
              variant="outlined"
              @click="agregarCliente()"
            >
              Guardar
            </v-btn>
          </div>
        </v-card-actions>
      </v-card>
    </v-row>
  </v-dialog>
</template>

<script setup lang="ts">
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";
import { ref } from "vue";

const appstore = useAppStore();

const { dialogreg, clientenuevo } = storeToRefs(appstore);

//*********************************** */

const nombres = ref("");
const apellidos = ref("");
const email = ref("");
const clave = ref("");

//*********************************** */

const agregarCliente = () => {
  clientenuevo.value.Nombres = nombres.value;
  clientenuevo.value.Apellidos = apellidos.value;
  clientenuevo.value.Email = email.value;
  clientenuevo.value.Clave = clave.value;

  console.log(clientenuevo.value);

  appstore.agregarCliente();
};
</script>
