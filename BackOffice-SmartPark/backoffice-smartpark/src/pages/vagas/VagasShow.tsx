import { Show, SimpleShowLayout, FunctionField, Labeled } from "react-admin";
import StatusVagaChip from "../../components/StatusVagaChip";
import TipoVagaField from "../../components/TipoVagaField";
import { Grid2 } from "@mui/material";

export const VagasShow = () => (
  <Show>
    <SimpleShowLayout>
      <Grid2 container spacing={4}>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="ID Estacionamento"
              source="idEstacionamento"
              render={(record) => `${record.idEstacionamento}`}
            />
          </Labeled>
        </Grid2>

        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="ID"
              source="id"
              render={(record) => `${record.id}`}
            />
          </Labeled>
        </Grid2>

        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Status"
              source="statusDescricao"
              render={(record) => (
                <StatusVagaChip status={record.statusDescricao} />
              )}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Tipo da Vaga"
              source="tipoVagaDescricao"
              render={(record) => (
                <TipoVagaField tipoVaga={record.tipoVagaDescricao} />
              )}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Valor por Hora"
              source="valorHora"
              render={(record) => `R$${record.valorHora},00`}
            />
          </Labeled>
        </Grid2>
      </Grid2>
    </SimpleShowLayout>
  </Show>
);
