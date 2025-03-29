import { useState, useEffect } from "react";
import { Status } from "../../interfaces/Vagas";
import { buscaTipoVaga } from "../buscaTipoVaga";

const useBuscaTipoVaga = () => {
  const [data, setData] = useState<Status[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getData = async () => {
      setLoading(true);
      try {
        const result = await buscaTipoVaga();
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

export default useBuscaTipoVaga;
