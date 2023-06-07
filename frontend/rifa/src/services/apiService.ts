import axios from "axios";

const apiService = axios.create({
  baseURL: import.meta.env.API_SERVICE,
  withCredentials: false,
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

/*Añadir a las llamadas /servicio*/
export default apiService;
