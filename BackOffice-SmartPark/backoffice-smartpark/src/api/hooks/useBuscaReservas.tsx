import { useState, useEffect } from "react";
import { Reserva } from "../../interfaces/Vagas";
import buscaReservas from "../buscaReservas";

const useBuscaReservas = () => {
  const [data, setData] = useState<Reserva[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getData = async () => {
      setLoading(true);
      try {
        const result = await buscaReservas();
        setData(result);
      } catch (err: any) {
        setError(err);
      } finally {
        setLoading(false);
      }
    };

    getData();
  }, []);

  return { data, loading, error };
};

export default useBuscaReservas;
