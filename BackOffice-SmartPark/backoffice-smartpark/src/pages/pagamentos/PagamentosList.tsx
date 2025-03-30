import {
  List,
  Datagrid,
  FunctionField,
  EditButton,
  DeleteButton,
} from "react-admin";
import { Pagamento } from "../../interfaces/Pagamentos";
import MetodoPagamentoChip from "../../components/MetodoPagamentoChip";
import StatusPagamentoChip from "../../components/StatusPagamentoChipProps ";

export const PagamentosList = () => (
  <List>
    <Datagrid>
      <FunctionField
        source="id"
        render={(record: Pagamento) => `${record.id?.slice(0, 8)}...`}
      />
      <FunctionField
        source="idReserva"
        render={(record: Pagamento) => `${record.idReserva?.slice(0, 8)}...`}
      />
      <FunctionField
        source="idUsuario"
        render={(record: Pagamento) => `${record.idUsuario?.slice(0, 8)}...`}
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
      <EditButton />
      <DeleteButton />
    </Datagrid>
  </List>
);
