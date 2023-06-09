import { ref } from "vue";
import { defineStore } from "pinia";
import axios from "axios";
import { Cliente } from "@/Interfaces/ICliente";
import { ClienteNuevo } from "@/Interfaces/IClienteNuevo";

export const useAppStore = defineStore("appstore", () => {
  const token = ref("");

  const dialog = ref(false);

  const dialogreg = ref(false);

  const lectorqr = ref(false);

  const clientenuevo = ref<ClienteNuevo>({
    Nombres: "",
    Apellidos: "",
    Email: "",
    Clave: "",
  });

  //********************** */

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

  //*********************** */

  const agregarCliente = async () => {
    const instance = axios.create({
      baseURL: "http://localhost:7071/api/Cliente",
      timeout: 1000,
      headers: {
        "Content-type": "application/json",
        Authorization: `Bearer ${token.value}`,
      },
    });

    await instance
      .post("PostCliente", {
        Nombres: clientenuevo.value.Nombres,
        Apellidos: clientenuevo.value.Apellidos,
        Email: clientenuevo.value.Email,
        Clave: clientenuevo.value.Clave,
      })
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => console.error(error));
  };

  //************************* */

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

  //*********************** */

  return {
    lectorqr,
    dialog,
    dialogreg,
    clientenuevo,
    agregarCliente,
    getClientes,
    autenticacion,
  };
});
