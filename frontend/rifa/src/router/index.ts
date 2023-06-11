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
    path: "/blog",
    name: "blog",
    component: () => import("@/views/BlogView.vue"),
  },

  {
    path: "/contacto",
    name: "contacto",
    component: () => import("@/views/ContactoView.vue"),
  },

  {
    path: "/premios",
    name: "premios",
    component: () => import("@/views/PremiosView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
