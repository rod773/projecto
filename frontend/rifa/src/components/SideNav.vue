<template>
  <v-list-item
    prepend-avatar="@/assets/logo/logo.png"
    title="Rifa"
  ></v-list-item>

  <v-divider></v-divider>

  <v-list density="compact" nav>
    <v-list-item
      prepend-icon="mdi-view-dashboard"
      title="Inicio"
      value="inicio"
      :to="{
        name: 'inicio',
        params: {
          id: 'inicio',
        },
      }"
    >
    </v-list-item>
    <v-list-item
      prepend-icon="mdi-forum"
      title="Acerca de"
      value="acercade"
      :to="{
        name: 'acercade',
        params: {
          id: 'acercade',
        },
      }"
    ></v-list-item>
    <v-list-item
      prepend-icon="mdi-view-dashboard"
      title="Blog"
      value="blog"
      :to="{
        name: 'blog',
        params: {
          id: 'blog',
        },
      }"
    ></v-list-item>
    <v-list-item
      prepend-icon="mdi-forum"
      title="Contacto"
      value="contacto"
      :to="{
        name: 'contacto',
        params: {
          id: 'contacto',
        },
      }"
    >
    </v-list-item>
  </v-list>
</template>

<script setup lang="ts"></script>
