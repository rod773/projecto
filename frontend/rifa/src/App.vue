<template>
  <v-app>
    <v-app-bar id="headertop">
      <img src="@/assets/logo.png" alt="" />
      <v-toolbar-title>Menu</v-toolbar-title>
      <v-btn light @click="getClientes()">getclientes</v-btn>
      <v-btn light @click="agregarCliente()">agregar</v-btn>
      <v-btn light @click="autenticacion()">auntenticar</v-btn>
    </v-app-bar>
    <v-app-bar id="headerbottom">
      <img src="@/assets/logo.png" alt="" />
      <v-toolbar-title>Menu</v-toolbar-title>
    </v-app-bar>
    <v-content>
      <loading />
      <router-view></router-view>
    </v-content>
    <v-btn class="btn-up" icon @click="scrollUp()"
      ><v-icon color="white">mdi-arrow-up</v-icon></v-btn
    >
    <v-footer dark>
      <v-layout justify-center> </v-layout>
    </v-footer>
  </v-app>
</template>

<script setup lang="ts">
import "@/styles/style.scss";
import Loading from "@/components/Loading.vue";
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";
import { onMounted, ref } from "vue";

const headertop = ref();

const headerbottom = ref();

const appstore = useAppStore();

const { clientenuevo } = storeToRefs(appstore);

//*********** */

const autenticacion = () => {
  appstore.autenticacion();
};

//************* */

const getClientes = () => {
  appstore.getClientes();
};

//******************* */

const agregarCliente = () => {
  clientenuevo.value.Nombres = "mario";
  clientenuevo.value.Apellidos = "suarez";
  clientenuevo.value.Email = "mario@gmail.com";
  clientenuevo.value.Clave = "fdgadasd";

  appstore.agregarCliente();
};

//****************** */

const scrollUp = () => {
  let pos = window.scrollY;
  let interval = setInterval(() => {
    pos = document.documentElement.scrollTop = pos - 2;
    if (pos < 100) clearInterval(interval);
  }, 1);
};

//************* */

window.addEventListener("scroll", () => {
  let pos = window.scrollY;
  if (pos > 100) {
    headertop.value.style.display = "none";
    headerbottom.value.style.top = 0;
  } else {
    headertop.value.style.display = "block";
    headerbottom.value.style.top = "100px";
    headerbottom.value.style.display = "none";
    setTimeout(() => (headerbottom.value.style.display = "block"), 500);
  }
});

//*************** */

onMounted(() => {
  headertop.value = document.querySelector("#headertop");
  headerbottom.value = document.querySelector("#headerbottom");
  setTimeout(() => {
    headerbottom.value.style.top = "100px";
    headertop.value.style.top = "0px";
    document.documentElement.scrollTop = 0;
  }, 100);
});
</script>
