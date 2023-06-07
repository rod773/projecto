import { ref, computed } from "vue";
import { defineStore } from "pinia";
import apiService from "@/services/apiService";
import axios from "axios";

export const useAppStore = defineStore("appstore", () => {
  const getClientes = () => {
    axios
      .get("http://localhost:7071/api/Cliente/GetClientes")
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
        console.log(response);
      })
      .catch((error) => console.error(error));
  };

  return { getClientes, autenticacion };
});

// export const useAppStore = defineStore("app", {
//   state: () => ({

//   }),
// });
