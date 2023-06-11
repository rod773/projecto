<template>
  <v-row>
    <v-col cols="12" class="d-flex justify-center">
      <div class="text-h2">Blog</div>
    </v-col>
  </v-row>
  <v-row id="contenido">
    <v-col cols="6">
      <v-layout class="d-flex justify-center">
        <v-flex xs12 sm6 offset-sm3>
          <v-card class="bg-indigo-darken-4">
            <v-img
              width="400px"
              height="400px"
              src="@/assets/img/blog1.jpg"
              aspect-ratio="2.75"
            ></v-img>

            <v-card-title primary-title>
              <div>
                <h3 class="headline mb-0">Premio Safari Africa</h3>
                <div>{{ card_text }}</div>
              </div>
            </v-card-title>

            <v-card-actions>
              <v-btn flat color="orange">Share</v-btn>
              <v-btn flat color="orange">Explore</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-col>
    <v-col cols="6">
      <v-layout class="d-flex justify-center">
        <v-flex xs12 sm6 offset-sm3>
          <v-card class="bg-indigo-darken-4">
            <v-img
              width="400px"
              height="400px"
              src="@/assets/img/blog2.jpg"
              aspect-ratio="2.75"
            ></v-img>

            <v-card-title primary-title>
              <div>
                <h3 class="headline mb-0">Premio Crucero Caribe</h3>
                <div>{{ card_text }}</div>
              </div>
            </v-card-title>

            <v-card-actions>
              <v-btn flat color="orange">Share</v-btn>
              <v-btn flat color="orange">Explore</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-col>
  </v-row>
  <v-row>
    <v-col cols="6">
      <v-layout class="d-flex justify-center">
        <v-flex xs12 sm6 offset-sm3>
          <v-card class="bg-indigo-darken-4">
            <v-img
              width="400px"
              height="400px"
              src="@/assets/img/blog3.png"
              aspect-ratio="2.75"
            ></v-img>

            <v-card-title primary-title>
              <div>
                <h3 class="headline mb-0">Premio Viaje a Paris</h3>
                <div>{{ card_text }}</div>
              </div>
            </v-card-title>

            <v-card-actions>
              <v-btn flat color="orange">Share</v-btn>
              <v-btn flat color="orange">Explore</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-col>
    <v-col cols="6">
      <v-layout class="d-flex justify-center">
        <v-flex xs12 sm6 offset-sm3>
          <v-card class="bg-indigo-darken-4">
            <v-img
              width="400px"
              height="400px"
              src="@/assets/img/blog4.jpg"
              aspect-ratio="2.75"
            ></v-img>

            <v-card-title primary-title>
              <div>
                <h3 class="headline mb-0">Premio Viaje a Roma</h3>
                <div>{{ card_text }}</div>
              </div>
            </v-card-title>

            <v-card-actions>
              <v-btn flat color="orange">Share</v-btn>
              <v-btn flat color="orange">Explore</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { ref } from "vue";

const card_text = ref();
</script>

<style scoped lang="scss">
#contenido {
  .v-card {
    max-width: 500px;
    height: 500px;
  }
}
</style>
