import { useState, useEffect } from "react";
import buscaMetodoPagamento from "../buscaMetodoPagamento";
import { MetodoPagamento } from "../../interfaces/Pagamentos";

const useBuscaMetodoPagamento = () => {
  const [data, setData] = useState<MetodoPagamento[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getData = async () => {
      setLoading(true);
      try {
        const result = await buscaMetodoPagamento();
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

export default useBuscaMetodoPagamento;
