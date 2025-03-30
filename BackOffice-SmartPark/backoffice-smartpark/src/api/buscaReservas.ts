import { Reserva } from "../interfaces/Vagas";
import { apiReservas } from "./apiConfig";

export const buscaReservas = async (): Promise<Reserva[]> => {
  try {
    const response = await apiReservas.get<Reserva[]>("/reservas");
    return response.data.reservas;
  } catch (error: any) {
    throw error.response?.data || error.message;
  }
};

export default buscaReservas;
