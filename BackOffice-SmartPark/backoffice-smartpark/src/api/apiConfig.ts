import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7250/v1",
  headers: {
    "Content-Type": "application/json",
  },
});

export default api;
