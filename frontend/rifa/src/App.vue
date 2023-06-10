<template>
  <v-app>
    <v-container fluid class="ma-0 pa-0">
      <v-row class="ma-0 pa-0 row-header" id="headertop">
        <v-col cols="3" class="header header-nav ma-0 pa-0">
          <v-btn
            outline
            large
            color="indigo"
            icon
            @click.stop="drawer = !drawer"
          >
            <v-icon>mdi-menu</v-icon>
          </v-btn>
        </v-col>

        <v-col cols="9" class="menu-btn">
          <v-btn light @click="ingresar()">Ingreso</v-btn>
          <v-btn light @click="registro()">Registro</v-btn>
          <v-btn light @click="leerqr()">Leer QR</v-btn>
          <v-btn light @click="crearQR()">Crear QR</v-btn>
        </v-col>
      </v-row>

      <v-row class="ma-0 pa-0 row-header" id="headerbottom">
        <v-col cols="3" class="header header-logo ma-0 pa-0">
          <v-btn
            outline
            large
            color="transparent"
            icon
            @click.stop="drawer = !drawer"
          >
            <img src="@/assets/logo/logo_1.svg" alt="" />
          </v-btn>
        </v-col>
        <v-col cols="9" class="menu-btn">
          <!-- <v-btn light @click="getClientes()">getclientes</v-btn>
          <v-btn light @click="agregarCliente()">agregar</v-btn>
          <v-btn light @click="autenticacion()">auntenticar</v-btn> -->
        </v-col>
      </v-row>
    </v-container>

    <v-container fluid class="ma-0 pa-0">
      <v-row class="ma-0 pa-0">
        <v-col cols="12" class="parallax">
          <img src="@/assets/img/titulo.svg" alt="" />
        </v-col>
      </v-row>
      <v-row class="ma-0 pa-0">
        <v-col cols="8" class="col1" />
        <v-col cols="4" class="col2" />
      </v-row>
    </v-container>
    <v-container>
      <router-view></router-view>
      <v-btn
        class="btn-up"
        @click="scrollUp()"
        outline
        large
        color="indigo"
        icon
        ><v-icon color="white">mdi-arrow-up</v-icon></v-btn
      >
    </v-container>
    <v-container fluid class="ma-0 pa-0 elem">
      <v-col>
        <loading />
      </v-col>
      <v-navigation-drawer v-model="drawer" temporary>
        <SideNav />
      </v-navigation-drawer>
      <LoginForm />
      <RegisterForm />
      <LectorQR />
      <CrearQR />
    </v-container>
  </v-app>
</template>

<script setup lang="ts">
import "vuetify/styles";
import "@/styles/style.scss";
import SideNav from "@/components/SideNav.vue";
import LoginForm from "@/components/LoginForm.vue";
import RegisterForm from "@/components/RegisterForm.vue";
import LectorQR from "@/components/LectorQR.vue";
import CrearQR from "@/components/CrearQR.vue";
import Loading from "@/components/Loading.vue";
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";
import { onMounted, ref } from "vue";

const appstore = useAppStore();

const { clientenuevo, dialog, dialogreg, lectorqr, crearqr } =
  storeToRefs(appstore);

//**************************************** */

const drawer = ref(false);

const svgcontainer = ref();

//*********** */

const autenticacion = () => {
  appstore.autenticacion();
};

//************* */

const getClientes = () => {
  appstore.getClientes();
};

//******************* */
const ingresar = () => {
  dialog.value = !dialog.value;
  reload();
};
//******************* */

const registro = () => {
  dialogreg.value = !dialogreg.value;

  reload();
};
//******************* */

const leerqr = () => {
  lectorqr.value = !lectorqr.value;

  reload();
};
//******************* */

const crearQR = () => {
  crearqr.value = !crearqr.value;

  reload();
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
const reload = () => {
  svgcontainer.value = document.querySelector(".svg-container");
  svgcontainer.value.style.display = "block";
  svgcontainer.value.style.opacity = "0";
  svgcontainer.value.style.visibility = "hidden";
  setTimeout(() => {
    svgcontainer.value.style.opacity = "1";
    svgcontainer.value.style.visibility = "visible";
  }, 500);
  setTimeout(() => {
    svgcontainer.value.style.display = "none";
  }, 5000);
};
//****************** */

const scrollUp = () => {
  let pos = window.scrollY;
  let interval = setInterval(() => {
    pos = document.documentElement.scrollTop = pos - 2;
    if (pos < 2) clearInterval(interval);
  }, 1);
};

//************* */

onMounted(() => {
  setTimeout(() => {
    document.documentElement.scrollTop = 0;
  }, 100);
});
</script>
