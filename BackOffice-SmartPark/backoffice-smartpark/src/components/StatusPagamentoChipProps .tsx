import React from "react";
import { Chip } from "@mui/material";

interface StatusPagamentoChipProps {
  statusPagamento: number;
}

const StatusPagamentoChip: React.FC<StatusPagamentoChipProps> = ({
  statusPagamento,
}) => {
  const statusMap: Record<number, string> = {
    0: "PENDENTE",
    1: "EFETUADO",
    2: "RECUSADO",
  };

  const statusDescricao = statusMap[statusPagamento];
  const corStatus =
    statusPagamento === 0
      ? "warning"
      : statusPagamento === 1
        ? "success"
        : "error";

  return (
    <Chip
      label={`${statusDescricao}`}
      color={corStatus}
      sx={{ textTransform: "uppercase" }}
    />
  );
};

export default StatusPagamentoChip;
