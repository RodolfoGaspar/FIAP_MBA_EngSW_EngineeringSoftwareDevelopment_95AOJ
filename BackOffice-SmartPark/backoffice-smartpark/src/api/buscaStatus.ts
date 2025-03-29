import api from "./apiConfig";
import { Status } from "../interfaces/Vagas";

export const buscaStatus = async (): Promise<Status[]> => {
  try {
    const response = await api.get<Status[]>("/vagas/status");
    return response.data;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaStatus;
