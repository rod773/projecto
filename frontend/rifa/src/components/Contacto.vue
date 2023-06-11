<template>
  <v-row justify="center">
    <v-card color="teal" theme="dark" width="600">
      <v-card-title>
        <div class="text-h5 text-center font-weight-light">Contacto</div>
      </v-card-title>

      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12">
              <v-text-field label="Nombres*" required></v-text-field>
            </v-col>

            <v-col cols="12">
              <v-text-field label="Apellidos*" required></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field label="Email*" required></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-textarea
                v-model="mensaje"
                auto-grow
                box
                color="deep-purple"
                label="Escribe tu mensaje"
                rows="1"
              ></v-textarea>
            </v-col>
          </v-row>
        </v-container>
        <div class="text-h7 text-center text-red">*campo requerido</div>
      </v-card-text>
      <v-card-actions class="pa-4 ma-5 d-flec justify-center align-center">
        <v-btn class="bg-success" min-width="92" rounded variant="outlined">
          Enviar
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-row>
</template>

<script setup lang="ts">
import { ref } from "vue";

const mensaje = ref();
</script>
