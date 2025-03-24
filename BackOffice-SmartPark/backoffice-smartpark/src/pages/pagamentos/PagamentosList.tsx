import { List, Datagrid, TextField } from "react-admin";

export const PagamentosList = () => (
  <List>
    <Datagrid>
      <TextField source="status" />
      <TextField source="tipoVaga" />
      <TextField source="valorHora" />
      <TextField source="idEstacionamento" />
      <TextField source="id" />
    </Datagrid>
  </List>
);
