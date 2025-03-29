export interface Pagamento {
  id: string;
  idReserva: string;
  idUsuario: string;
  valor: number;
  metodoPagamento: MetodoPagamento["id"];
  metodoPagamentoDescricao: MetodoPagamento["name"];
  statusPagamento: StatusPagamento["id"];
  statusPagamentoDescricao: StatusPagamento["name"];
  criadoEm: string;
  alteradoEm: string | null;
}

export interface MetodoPagamento {
  id: 0 | 1 | 2 | 3;
  name: "PIX" | "DEBITO" | "CREDITO" | "DINHEIRO";
}

export interface StatusPagamento {
  id: 0 | 1 | 2;
  name: "PENDENTE" | "EFETUADO" | "RECUSADO";
}
