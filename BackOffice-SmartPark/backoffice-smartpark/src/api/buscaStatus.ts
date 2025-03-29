import { Status } from "../interfaces/Vagas";
import { apiVagas } from "./apiConfig";

export const buscaStatus = async (): Promise<Status[]> => {
  try {
    const response = await apiVagas.get<Status[]>("/vagas/status");
    return response.data;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaStatus;
