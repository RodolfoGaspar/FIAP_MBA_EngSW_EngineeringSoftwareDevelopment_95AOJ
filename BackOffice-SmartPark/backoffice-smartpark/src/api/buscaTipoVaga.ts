import { Status } from "../interfaces/Vagas";
import { apiVagas } from "./apiConfig";

export const buscaTipoVaga = async (): Promise<Status[]> => {
  try {
    const response = await apiVagas.get<Status[]>("/vagas/tipos");
    return response.data;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaTipoVaga;
