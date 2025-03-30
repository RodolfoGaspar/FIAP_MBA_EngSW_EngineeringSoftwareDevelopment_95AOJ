import axios from "axios";

const API_BASE_URL = "http://localhost";

export const apiVagas = axios.create({
  baseURL: `${API_BASE_URL}:5001/v1`, // Ajuste para a porta correta no Docker
  headers: {
    "Content-Type": "application/json",
  },
});

export const apiPagamentos = axios.create({
  baseURL: `${API_BASE_URL}:5003/v1`, // Ajuste para a porta correta no Docker
  headers: {
    "Content-Type": "application/json",
  },
});
export const apiReservas = axios.create({
  baseURL: `${API_BASE_URL}:5002/v1`,
  headers: {
    "Content-Type": "application/json",
  },
});
