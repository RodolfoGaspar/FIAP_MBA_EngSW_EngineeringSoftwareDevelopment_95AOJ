import { Estacionamento } from "../interfaces/Vagas";
import { apiVagas } from "./apiConfig";

export const buscaEstacionamentos = async (): Promise<Estacionamento[]> => {
  try {
    const response = await apiVagas.get<Estacionamento[]>("/estacionamentos");
    return response.data;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaEstacionamentos;
