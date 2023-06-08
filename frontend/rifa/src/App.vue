<template>
  <v-app>
    <v-navigation-drawer v-model="drawer" temporary>
      <v-list-item
        prepend-avatar="https://randomuser.me/api/portraits/men/78.jpg"
        title="John Leider"
      ></v-list-item>

      <v-divider></v-divider>

      <v-list density="compact" nav>
        <v-list-item
          prepend-icon="mdi-view-dashboard"
          title="Home"
          value="home"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-forum"
          title="About"
          value="about"
        ></v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-container fluid class="ma-0 pa-0">
      <v-row class="ma-0 pa-0 row-header" id="headertop">
        <v-col cols="3" class="header header-logo ma-0 pa-0">
          <img src="@/assets/logo/logo.png" alt="" />
        </v-col>
        <v-col cols="9" class="menu-title">
          <v-title class="text-h2">Menu</v-title>
        </v-col>
      </v-row>

      <v-row class="ma-0 pa-0 row-header" id="headerbottom">
        <v-col cols="3" class="header header-logo ma-0 pa-0">
          <img src="@/assets/logo/logo.png" alt=""
        /></v-col>
        <v-col cols="9" class="menu-title">
          <v-btn light @click="getClientes()">getclientes</v-btn>
          <v-btn light @click="agregarCliente()">agregar</v-btn>
          <v-btn light @click="autenticacion()">auntenticar</v-btn>
          <v-btn light @click="ingresar()">Ingresar</v-btn>
          <v-btn color="primary" @click.stop="drawer = !drawer"> Toggle </v-btn>
        </v-col>
        <v-col>
          <loading />
        </v-col>
      </v-row>
      <v-row class="ma-0 pa-0">
        <v-col cols="12" class="parallax"></v-col>
      </v-row>
      <v-row class="ma-0 pa-0">
        <v-col cols="8" class="col1" />
        <v-col cols="4" class="col2" />
      </v-row>
    </v-container>
  </v-app>

  <router-view v-if="dialog"></router-view>
  <v-btn class="btn-up" icon @click="scrollUp()"
    ><v-icon color="white">mdi-arrow-up</v-icon></v-btn
  >
</template>

<script setup lang="ts">
import "vuetify/styles";
import "@/styles/style.scss";
import Loading from "@/components/Loading.vue";
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";
import { onMounted, ref } from "vue";

const headertop = ref();

const headerbottom = ref();

const appstore = useAppStore();

const { clientenuevo } = storeToRefs(appstore);

const dialog = ref(false);

const drawer = ref(true);

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
  setTimeout(() => {
    document.documentElement.scrollTop = 0;
  }, 100);
});
</script>
