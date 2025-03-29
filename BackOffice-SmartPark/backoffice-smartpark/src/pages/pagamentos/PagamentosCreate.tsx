import {
  Create,
  SimpleForm,
  TextInput,
  SelectInput,
  NumberInput,
} from "react-admin";
import { Grid2 } from "@mui/material";
import useBuscaMetodoPagamento from "../../api/hooks/useBuscaMetodoPagamento";
import useBuscaStatusPagamento from "../../api/hooks/useBuscaStatusPagamento";

export const PagamentosCreate = () => {
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

  if (errorMetodoPagamento || errorStatusPagamento)
    return <p>Erro: {errorMetodoPagamento || errorStatusPagamento}</p>;

  return (
    <Create>
      <SimpleForm>
        <Grid2 container spacing={2} sx={{ width: "100%" }}>
          <Grid2 size={{ xs: 12, md: 6 }}>
            <TextInput
              fullWidth
              source="idUsuario"
              label="ID do Usuário"
              defaultValue="3fa85f64-5717-4562-b3fc-2c963f66afa6"
              disabled
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
            <TextInput fullWidth source="idReserva" label="ID da Reserva" />
          </Grid2>
        </Grid2>
      </SimpleForm>
    </Create>
  );
};
