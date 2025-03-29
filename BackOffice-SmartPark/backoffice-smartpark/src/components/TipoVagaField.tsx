import React from "react";
import { Roofing, WbSunny } from "@mui/icons-material";
import { Box, Typography } from "@mui/material";

interface TipoVagaProps {
  tipoVaga: "COBERTA" | "DESCOBERTA"; // Define the possible values for tipoVaga
}

const TipoVagaField: React.FC<TipoVagaProps> = ({ tipoVaga }) => {
  let label = "";
  let icon = null;

  switch (tipoVaga) {
    case "COBERTA":
      label = "Coberta";
      icon = <Roofing />;
      break;
    case "DESCOBERTA":
      label = "Descoberta";
      icon = <WbSunny />;
      break;
    default:
      label = "Desconhecido";
      icon = <span>?</span>;
  }

  return (
    <Box display="flex" alignItems="center">
      {icon}
      <Typography variant="body2" style={{ marginLeft: "8px" }}>
        {label}
      </Typography>
    </Box>
  );
};

export default TipoVagaField;
