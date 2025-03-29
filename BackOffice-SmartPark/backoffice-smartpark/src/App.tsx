import { Admin, Resource } from "react-admin";
import { VagasList } from "./pages/vagas/VagasList";
import { VagasCreate } from "./pages/vagas/VagasCreate";
import { PagamentosList } from "./pages/pagamentos/PagamentosList";
import { PagamentosCreate } from "./pages/pagamentos/PagamentosCreate";
import CustomLayout from "./components/CustomLayout";
import dataProvider from "./dataProvider";
import { VagasShow } from "./pages/vagas/VagasShow";
import { PagamentoShow } from "./pages/pagamentos/PagamentoShow";

export const App = () => (
  <Admin layout={CustomLayout} dataProvider={dataProvider}>
    <Resource
      name="vagas"
      list={VagasList}
      create={VagasCreate}
      show={VagasShow}
    />
    <Resource
      name="pagamentos"
      list={PagamentosList}
      create={PagamentosCreate}
      show={PagamentoShow}
    />
  </Admin>
);
