import { MetodoPagamento } from "../interfaces/Pagamentos";
import { apiPagamentos } from "./apiConfig";

export const buscaMetodoPagamento = async (): Promise<MetodoPagamento[]> => {
  try {
    const response = await apiPagamentos.get<MetodoPagamento[]>(
      "/pagamentos/metodos",
    );
    return response.data;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaMetodoPagamento;
