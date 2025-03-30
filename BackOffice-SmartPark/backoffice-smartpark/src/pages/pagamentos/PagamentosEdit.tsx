import {
  Edit,
  SimpleForm,
  TextInput,
  SelectInput,
  NumberInput,
} from "react-admin";
import { Grid2 } from "@mui/material";
import useBuscaMetodoPagamento from "../../api/hooks/useBuscaMetodoPagamento";
import useBuscaStatusPagamento from "../../api/hooks/useBuscaStatusPagamento";
import useBuscaReservas from "../../api/hooks/useBuscaReservas";

export const PagamentosEdit = () => {
  const {
    data: metodoPagamentoData,
    loading: loadingMetodoPagamento,
    error: errorMetodoPagamento,
  } = useBuscaMetodoPagamento();

  const {
    data: statusPagamentoData,
    loading: loadingStatusPagamento,
    error: errorStatusPagamento,
  } = useBuscaStatusPagamento();

  const {
    data: reservasData,
    loading: loadingReservas,
    error: errorReservas,
  } = useBuscaReservas();

  if (errorMetodoPagamento || errorStatusPagamento || errorReservas)
    return (
      <p>
        Erro: {errorMetodoPagamento || errorStatusPagamento || errorReservas}
      </p>
    );

  return (
    <Edit>
      <SimpleForm>
        <Grid2 container spacing={2} sx={{ width: "100%" }}>
          <Grid2 size={{ xs: 12, md: 6 }}>
            <TextInput
              fullWidth
              source="idUsuario"
              label="ID do Usuário"
              InputProps={{ readOnly: true }}
            />
          </Grid2>
          <Grid2 size={{ xs: 12, md: 6 }}>
            <SelectInput
              fullWidth
              source="metodoPagamento"
              disabled={loadingMetodoPagamento}
              choices={metodoPagamentoData?.map((metodo) => ({
                id: metodo.id,
                name: metodo.name,
              }))}
              optionText="name"
              optionValue="id"
            />
          </Grid2>

          <Grid2 size={{ xs: 12, md: 6 }}>
            <SelectInput
              fullWidth
              source="statusPagamento"
              disabled={loadingStatusPagamento}
              choices={statusPagamentoData?.map((status) => ({
                id: status.id,
                name: status.name,
              }))}
              optionText="name"
              optionValue="id"
            />
          </Grid2>

          <Grid2 size={{ xs: 12, md: 6 }}>
            <NumberInput fullWidth source="valor" label="Valor" />
          </Grid2>

          <Grid2 size={{ xs: 12, md: 6 }}>
            <SelectInput
              fullWidth
              source="idReserva"
              label="ID da reserva"
              disabled={loadingReservas}
              choices={reservasData?.map((reserva) => ({
                id: reserva.id,
                name: reserva.id,
              }))}
              optionText="name"
              optionValue="id"
            />
          </Grid2>
        </Grid2>
      </SimpleForm>
    </Edit>
  );
};
