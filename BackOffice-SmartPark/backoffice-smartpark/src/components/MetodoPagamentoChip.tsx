import React from "react";
import { Chip } from "@mui/material";

interface MetodoPagamentoChipProps {
  metodoPagamento: number;
}

const MetodoPagamentoChip: React.FC<MetodoPagamentoChipProps> = ({
  metodoPagamento,
}) => {
  const metodoMap: Record<number, string> = {
    0: "PIX",
    1: "DEBITO",
    2: "CREDITO",
    3: "DINHEIRO",
  };

  const metodoDescricao = metodoMap[metodoPagamento];

  return (
    <Chip
      label={`${metodoDescricao}`}
      color="primary"
      sx={{ textTransform: "uppercase" }}
    />
  );
};

export default MetodoPagamentoChip;
