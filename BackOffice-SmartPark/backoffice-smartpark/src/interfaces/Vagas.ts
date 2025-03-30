export interface Vagas {
  id: string;
  idEstacionamento: string;
  status: number;
  statusDescricao: string;
  tipoVaga: number;
  tipoVagaDescricao: string;
  valorHora: number;
}

export interface Status {
  id: number;
  name: string;
}

export interface Estacionamento {
  id: number;
  nome: string;
}

export interface Reserva {
  id: number;
  nome: string;
}

export interface TipoVaga {
  id: number;
  name: string;
}
