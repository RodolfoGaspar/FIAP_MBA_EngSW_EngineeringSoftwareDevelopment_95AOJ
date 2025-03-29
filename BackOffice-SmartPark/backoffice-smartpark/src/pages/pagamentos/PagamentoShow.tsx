import { Show, SimpleShowLayout, FunctionField, Labeled } from "react-admin";
import { Grid2 } from "@mui/material";
import MetodoPagamentoChip from "../../components/MetodoPagamentoChip";
import StatusPagamentoChip from "../../components/StatusPagamentoChipProps ";

export const PagamentoShow = () => (
  <Show>
    <SimpleShowLayout>
      <Grid2 container spacing={4}>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="ID do Pagamento"
              source="id"
              render={(record) => `${record.id}`}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="ID da Reserva"
              source="idReserva"
              render={(record) => `${record.idReserva}`}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="ID do Usuário"
              source="idUsuario"
              render={(record) => `${record.idUsuario}`}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Método de Pagamento"
              source="metodoPagamento"
              render={(record) => (
                <MetodoPagamentoChip metodoPagamento={record.metodoPagamento} />
              )}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Status do Pagamento"
              source="statusPagamento"
              render={(record) => (
                <StatusPagamentoChip statusPagamento={record.statusPagamento} />
              )}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Valor"
              source="valor"
              render={(record) => `R$ ${record.valor},00`}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Criado Em"
              source="criadoEm"
              render={(record) => new Date(record.criadoEm).toLocaleString()}
            />
          </Labeled>
        </Grid2>
        <Grid2 size={{ xs: 12, md: 6 }}>
          <Labeled>
            <FunctionField
              label="Alterado Em"
              source="alteradoEm"
              render={(record) =>
                record.alteradoEm
                  ? new Date(record.alteradoEm).toLocaleString()
                  : "N/A"
              }
            />
          </Labeled>
        </Grid2>
      </Grid2>
    </SimpleShowLayout>
  </Show>
);
