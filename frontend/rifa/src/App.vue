<template>
  <v-app>
    <v-app-bar id="headertop" color="">
      <img src="@/assets/logo.png" alt="" />
      <v-toolbar-title>Menu</v-toolbar-title>
    </v-app-bar>
    <v-app-bar id="headerbottom">
      <img src="@/assets/logo.png" alt="" />
      <v-toolbar-title>Menu</v-toolbar-title>
    </v-app-bar>
    <v-content>
      <router-view></router-view>
    </v-content>
    <v-footer dark>
      <v-layout justify-center> footer </v-layout>
    </v-footer>
  </v-app>
</template>

<script setup lang="ts">
import "@/styles/style.scss";
import { onMounted, ref } from "vue";

const headertop = ref();

const headerbottom = ref();

window.addEventListener("scroll", () => {
  let pos = window.scrollY;
  if (pos > 50) {
    headertop.value.style.display = "none";
    headerbottom.value.style.top = 0;
  } else {
    headertop.value.style.display = "block";
    headerbottom.value.style.top = "64px";
  }
});

onMounted(() => {
  headertop.value = document.querySelector("#headertop");

  headerbottom.value = document.querySelector("#headerbottom");
});
</script>
