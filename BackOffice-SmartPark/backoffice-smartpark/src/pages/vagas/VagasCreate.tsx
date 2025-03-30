import { Create, SimpleForm, TextInput, SelectInput } from "react-admin";
import useBuscaTipoVaga from "../../api/hooks/useBuscaTipoVaga";
import useBuscaStatus from "../../api/hooks/useBuscaStatus";
import { Grid2 } from "@mui/material";
import useBuscaEstacionamentos from "../../api/hooks/useBuscaEstacionamentos";

export const VagasCreate = () => {
  const { data, loading, error } = useBuscaStatus();
  const {
    data: tipo,
    loading: loadingTipo,
    error: errorTipo,
  } = useBuscaTipoVaga();
  const {
    data: estacionamentos,
    loading: loadingEstacionamento,
    error: errorEstacionamento,
  } = useBuscaEstacionamentos();

  if (error || errorTipo || errorEstacionamento) return <p>Erro: {error}</p>;

  return (
    <Create>
      <SimpleForm>
        <Grid2 container spacing={2} sx={{ width: "100%" }}>
          <Grid2 size={{ xs: 12, md: 6 }}>
            <SelectInput
              fullWidth
              source="status"
              disabled={loading}
              choices={data?.map((status) => ({
                id: status.id,
                name: status.name,
              }))}
              optionText="name"
              optionValue="id"
            />
          </Grid2>
          <Grid2 size={{ xs: 12, md: 6 }}>
            <SelectInput
              fullWidth
              source="tipos"
              disabled={loadingTipo}
              choices={tipo?.map((status) => ({
                id: status.id,
                name: status.name,
              }))}
              optionText="name"
              optionValue="id"
            />
          </Grid2>
          <Grid2 size={{ xs: 12, md: 6 }}>
            <TextInput type="number" fullWidth source="valorHora" />
          </Grid2>
          <Grid2 size={{ xs: 12, md: 6 }}>
            <SelectInput
              fullWidth
              source="idEstacionamento"
              disabled={loadingEstacionamento}
              choices={estacionamentos?.map((estacionamento) => ({
                id: estacionamento.id,
                name: estacionamento.nome,
              }))}
              optionText="name"
              optionValue="id"
            />
          </Grid2>
        </Grid2>
      </SimpleForm>
    </Create>
  );
};
