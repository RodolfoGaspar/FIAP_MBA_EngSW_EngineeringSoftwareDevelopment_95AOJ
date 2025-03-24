import { Admin, Resource } from "react-admin";
import { VagasList } from "./pages/vagas/VagasList";
import { VagasCreate } from "./pages/vagas/VagasCreate";
import { PagamentosList } from "./pages/pagamentos/PagamentosList";
import { PagamentosCreate } from "./pages/pagamentos/PagamentosCreate";
import CustomLayout from "./components/CustomLayout";

export const App = () => (
  <Admin layout={CustomLayout}>
    <Resource name="vagas" list={VagasList} create={VagasCreate} />
    <Resource
      name="pagamentos"
      list={PagamentosList}
      create={PagamentosCreate}
    />
  </Admin>
);
