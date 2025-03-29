import React from "react";
import { Chip } from "@mui/material";

interface VagaChipProps {
  status: "DISPONIVEL" | "RESERVADA" | "BLOQUEADA";
}

const StatusVagaChip: React.FC<VagaChipProps> = ({ status }) => {
  let chipLabel = "";
  let chipColor = "";

  switch (status) {
    case "DISPONIVEL":
      chipLabel = "Disponível";
      chipColor = "#4CAF50";
      break;
    case "RESERVADA":
      chipLabel = "Reservada";
      chipColor = "#FF9800";
      break;
    case "BLOQUEADA":
      chipLabel = "Bloqueada";
      chipColor = "#F44336";
      break;
    default:
      chipLabel = "Desconhecido";
      chipColor = "grey";
  }

  return (
    <Chip
      label={chipLabel}
      style={{ backgroundColor: chipColor, color: "#fff" }}
    />
  );
};

export default StatusVagaChip;
