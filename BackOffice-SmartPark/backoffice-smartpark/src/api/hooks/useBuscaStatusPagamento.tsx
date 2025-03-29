import { useState, useEffect } from "react";
import { StatusPagamento } from "../../interfaces/Pagamentos";
import buscaStatusPagamento from "../buscaStatusPagamento";

const useBuscaStatusPagamento = () => {
  const [data, setData] = useState<StatusPagamento[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getData = async () => {
      setLoading(true);
      try {
        const result = await buscaStatusPagamento();
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

export default useBuscaStatusPagamento;
