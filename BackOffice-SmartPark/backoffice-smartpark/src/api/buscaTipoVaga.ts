import api from "./apiConfig";
import { Status } from "../interfaces/Vagas";

export const buscaTipoVaga = async (): Promise<Status[]> => {
  try {
    const response = await api.get<Status[]>("/vagas/tipos");
    return response.data;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaTipoVaga;
