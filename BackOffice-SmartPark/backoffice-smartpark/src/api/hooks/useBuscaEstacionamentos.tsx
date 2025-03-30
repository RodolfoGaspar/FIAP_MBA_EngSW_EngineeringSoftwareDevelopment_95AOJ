import { useState, useEffect } from "react";
import { Estacionamento } from "../../interfaces/Vagas";
import buscaEstacionamentos from "../buscaEstacionamentos";

const useBuscaEstacionamentos = () => {
  const [data, setData] = useState<Estacionamento[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getData = async () => {
      setLoading(true);
      try {
        const result = await buscaEstacionamentos();
        setData(result.estacionamenos);
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

export default useBuscaEstacionamentos;
