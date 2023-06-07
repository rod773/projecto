<template>
  <div class="svg-container">
    <svg
      id="svg"
      data-name="Capa 2"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 259 250"
    >
      <g id="Capa_1-2" data-name="Capa 1">
        <circle cx="52.55" cy="76.64" r="9.19" fill="indigo" opacity="0.1" />
        <circle cx="86.13" cy="45.36" r="9.19" fill="indigo" opacity="0.2" />
        <circle cx="131.06" cy="34.13" r="9.19" fill="indigo" opacity="0.3" />
        <circle cx="173.19" cy="45.36" r="9.19" fill="indigo" opacity="0.3" />
        <circle cx="207.66" cy="81.62" r="9.19" fill="indigo" opacity="0.4" />
        <circle cx="39.02" cy="121" r="9.19" fill="indigo" opacity="0.4" />
        <circle cx="218.64" cy="125" r="9.19" fill="indigo" opacity="0.5" />
        <circle cx="49.36" cy="165.36" r="9.19" fill="indigo" opacity="0.6" />
        <circle cx="79.74" cy="199.57" r="9.19" fill="indigo" opacity="0.7" />
        <circle cx="124.94" cy="213.11" r="9.19" fill="indigo" opacity="0.8" />
        <circle cx="173.19" cy="201.87" r="9.19" fill="indigo" opacity="0.9" />
        <circle cx="205.11" cy="169.96" r="9.19" fill="indigo" opacity="1" />
        <rect width="259" height="250" fill="none" />
      </g>

      <animateTransform
        attributeName="transform"
        type="rotate"
        from="0"
        to="360"
        dur="1"
        repeatCount="indefinite"
      />
    </svg>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";

const svgcontainer = ref();

onMounted(() => {
  svgcontainer.value = document.querySelector(".svg-container");
  svgcontainer.value.style.opacity = "0";
  svgcontainer.value.style.visibility = "hidden";
  setTimeout(() => {
    svgcontainer.value.style.opacity = "1";
    svgcontainer.value.style.visibility = "visible";
  }, 500);
  setTimeout(() => {
    svgcontainer.value.style.display = "none";
  }, 5000);
});
</script>

<style scoped lang="scss">
.svg-container {
  width: 100%;
  height: 100%;
  display: block;
  background-image: linear-gradient(
    180deg,
    rgba(#212529, 1),
    rgba(#6610f2, 0.3)
  );
}

svg {
  display: block;
  top: 5%;
  left: 25%;
  position: fixed;
  width: 50%;
}
</style>
