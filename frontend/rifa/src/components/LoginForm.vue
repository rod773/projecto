<template>
  <v-container class="fill-height" fluid>
    <v-row align="center" justify="center" dense>
      <v-col cols="12" sm="8" md="4" lg="4">
        <v-card elevation="0">
          <div class="text-center">
            <h1 class="mb-2">Login</h1>
          </div>
          <v-card-text>
            <v-form>
              <v-text-field
                label="Indroduce el email"
                name="email"
                prepend-inner-icon="mdi-email"
                type="email"
                class="rounded-0"
                outlined
              ></v-text-field>
              <v-text-field
                label="Introduce una clave"
                name="password"
                prepend-inner-icon="mdi-lock"
                type="password"
                suffix="| Forgot?"
                class="rounded-0"
                outlined
              ></v-text-field>
              <v-btn class="rounded-0" color="#000000" x-large block dark
                >Login</v-btn
              >
              <v-card-actions class="text--secondary">
                <v-checkbox color="#000000" label="Remember me"></v-checkbox>
                <v-spacer></v-spacer>
                <!-- <router-link :to="{ name: 'SignUp' }">Sign Up</router-link> -->
                No account?
                <a href="#" class="pl-2" style="color: #000000">Sign Up</a>
              </v-card-actions>
            </v-form>
          </v-card-text>
          <v-card-actions class="ml-6 mr-6 text-center">
            <p>By continuing, you agree to Fedorae Education's</p>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts"></script>

<style scoped lang="scss"></style>
