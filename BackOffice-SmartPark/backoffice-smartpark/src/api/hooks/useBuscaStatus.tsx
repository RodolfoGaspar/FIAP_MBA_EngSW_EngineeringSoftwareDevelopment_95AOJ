import { useState, useEffect } from "react";
import buscaStatus from "../buscaStatus";
import { Status } from "../../interfaces/Vagas";

const useBuscaStatus = () => {
  const [data, setData] = useState<Status[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getData = async () => {
      setLoading(true);
      try {
        const result = await buscaStatus();
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

export default useBuscaStatus;
