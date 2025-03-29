import { StatusPagamento } from "../interfaces/Pagamentos";
import { apiPagamentos } from "./apiConfig";

export const buscaStatusPagamento = async (): Promise<StatusPagamento[]> => {
  try {
    const response =
      await apiPagamentos.get<StatusPagamento[]>("/pagamentos/status");
    return response.data;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaStatusPagamento;
