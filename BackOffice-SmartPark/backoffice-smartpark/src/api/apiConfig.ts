import axios from "axios";

export const apiVagas = axios.create({
  baseURL: "http://localhost:5001/v1",
  headers: {
    "Content-Type": "application/json",
  },
});
export const apiPagamentos = axios.create({
  baseURL: "http://localhost:5003/v1",
  headers: {
    "Content-Type": "application/json",
  },
});
export const apiReservas = axios.create({
  baseURL: "http://localhost:5002/v1",
  headers: {
    "Content-Type": "application/json",
  },
});
