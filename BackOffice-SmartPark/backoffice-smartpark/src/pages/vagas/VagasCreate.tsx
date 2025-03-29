import { Create, SimpleForm, TextInput, SelectInput } from "react-admin";
import useBuscaTipoVaga from "../../api/hooks/useBuscaTipoVaga";
import useBuscaStatus from "../../api/hooks/useBuscaStatus";
import { Grid2 } from "@mui/material";

export const VagasCreate = () => {
  const { data, loading, error } = useBuscaStatus();
  const {
    data: tipo,
    loading: loadingTipo,
    error: errorTipo,
  } = useBuscaTipoVaga();

  if (error || errorTipo) return <p>Erro: {error}</p>;

  return (
    <Create>
      <SimpleForm>
        <Grid2 container spacing={2}>
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
            <TextInput fullWidth source="estacionamento" />
          </Grid2>
        </Grid2>
      </SimpleForm>
    </Create>
  );
};
