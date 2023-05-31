// Composables
import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "inicio",
    component: () => import("@/views/InicioView.vue"),
  },
  {
    path: "/acercade",
    name: "acercade",
    component: () => import("@/views/AcercadeView.vue"),
  },
  {
    path: "/contacto",
    name: "contacto",
    component: () => import("@/views/ContactoView.vue"),
  },
  {
    path: "/registro",
    name: "registro",
    component: () => import("@/views/RegistroView.vue"),
  },
  {
    path: "/blog",
    name: "blog",
    component: () => import("@/views/BlogView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
