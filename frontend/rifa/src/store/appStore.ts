import { ref } from "vue";
import { defineStore } from "pinia";
import axios from "axios";

export const useAppStore = defineStore("appstore", () => {
  const token = ref("");

  const getClientes = async () => {
    await axios
      .get("http://localhost:7071/api/Cliente/GetClientes", {
        headers: {
          "Content-type": "application/json",
          Authorization: `Bearer ${token.value}`,
        },
      })
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => console.error(error));
  };

  const autenticacion = async () => {
    const Usuario = {
      correo: "c@gmail.com",
      clave: "123",
    };

    await axios
      .post("http://localhost:7071/api/Autenticacion/Validar", Usuario)
      .then((response) => {
        console.log(response.data.token);
        token.value = response.data.token;
      })
      .catch((error) => console.error(error));
  };

  return { getClientes, autenticacion };
});
