import {
  List,
  Datagrid,
  FunctionField,
  EditButton,
  DeleteButton,
} from "react-admin";
import StatusVagaChip from "../../components/StatusVagaChip";
import TipoVagaField from "../../components/TipoVagaField";

export const VagasList = () => (
  <List>
    <Datagrid>
      <FunctionField
        source="idEstacionamento"
        render={(record) => `${record.idEstacionamento?.slice(0, 8)}...`}
      />
      <FunctionField
        source="id"
        render={(record) => `${record.id?.slice(0, 8)}...`}
      />
      <FunctionField
        source="tipoVagaDescricao"
        render={(record) => (
          <TipoVagaField tipoVaga={record.tipoVagaDescricao} />
        )}
      />
      <FunctionField
        source="statusDescricao"
        render={(record) => <StatusVagaChip status={record.statusDescricao} />}
      />
      <FunctionField
        source="valorHora"
        render={(record) => `R$${record.valorHora},00`}
      />
      <EditButton />
      <DeleteButton />
    </Datagrid>
  </List>
);
