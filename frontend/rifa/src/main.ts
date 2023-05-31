import App from "./App.vue";
import router from "./router";
import vuetify from "./plugins/vuetify";
import { loadFonts } from "./plugins/webfontloader";
import { createPinia } from "pinia";

// Composables
import { createApp } from "vue";

// Plugins
import { registerPlugins } from "@/plugins";

const app = createApp(App);

registerPlugins(app);

//import '@fontsource/open-sans';

loadFonts();
const pinia = createPinia();

createApp(App).use(pinia).use(router).use(vuetify).mount("#app");
