import axios from "axios";

export const apiVagas = axios.create({
  baseURL: "https://localhost:7250/v1",
  headers: {
    "Content-Type": "application/json",
  },
});
export const apiPagamentos = axios.create({
  baseURL: "https://localhost:7252/v1",
  headers: {
    "Content-Type": "application/json",
  },
});
