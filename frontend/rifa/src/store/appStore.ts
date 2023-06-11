import { ref, onMounted } from "vue";
import { defineStore } from "pinia";
import axios from "axios";
import { ClienteNuevo } from "@/Interfaces/IClienteNuevo";
import { Usuario } from "@/Interfaces/IUsuario";

export const useAppStore = defineStore("appstore", () => {
  onMounted(() => {
    autenticar("", "");
  });
  const token = ref("");

  const autenticado = ref(false);

  const dialogLogin = ref(false);

  const dialogreg = ref(false);

  const lectorqr = ref(false);

  const crearqr = ref(false);

  const imageqr = ref();

  const clientenuevo = ref<ClienteNuevo>({
    Nombres: "",
    Apellidos: "",
    Email: "",
    Clave: "",
  });

  const usuario = ref<Usuario>({
    correo: "",
    clave: "",
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

  const autenticar = async (email: string, password: string) => {
    usuario.value = {
      correo: email,
      clave: password,
    };

    await axios
      .post("http://localhost:7071/api/Autenticacion/Validar", usuario.value)
      .then((response) => {
        token.value = response.data.token;
        autenticado.value = true;
        dialogLogin.value = false;
        //console.log(token.value);
      })
      .catch((error) => {
        console.error(error);
        autenticado.value = false;
        dialogLogin.value = true;
      });

    return await token.value;
  };

  //*********************** */

  return {
    token,
    autenticado,
    autenticar,
    crearqr,
    imageqr,
    lectorqr,
    dialogLogin,
    dialogreg,
    clientenuevo,
    agregarCliente,
    getClientes,
  };
});
