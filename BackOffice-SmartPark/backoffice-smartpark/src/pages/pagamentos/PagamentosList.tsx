import { List, Datagrid, FunctionField } from "react-admin";
import { Pagamento } from "../../interfaces/Pagamentos";
import MetodoPagamentoChip from "../../components/MetodoPagamentoChip";
import StatusPagamentoChip from "../../components/StatusPagamentoChipProps ";

export const PagamentosList = () => (
  <List>
    <Datagrid>
      <FunctionField
        source="id"
        render={(record: Pagamento) => `${record.id}`}
      />
      <FunctionField
        source="idReserva"
        render={(record: Pagamento) => `${record.idReserva}`}
      />
      <FunctionField
        source="idUsuario"
        render={(record: Pagamento) => `${record.idUsuario}`}
      />
      <FunctionField
        source="metodoPagamento"
        render={(record: Pagamento) => (
          <MetodoPagamentoChip metodoPagamento={record.metodoPagamento} />
        )}
      />
      <FunctionField
        source="statusPagamento"
        render={(record: Pagamento) => (
          <StatusPagamentoChip statusPagamento={record.statusPagamento} />
        )}
      />
      <FunctionField
        source="valor"
        render={(record: Pagamento) => `R$${record.valor},00`}
      />
      <FunctionField
        source="criadoEm"
        render={(record: Pagamento) =>
          new Date(record.criadoEm).toLocaleString()
        }
      />
    </Datagrid>
  </List>
);
