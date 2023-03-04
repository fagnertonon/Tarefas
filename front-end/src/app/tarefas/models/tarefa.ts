import { Status } from "./status";

export class Tarefa {
  id: string;
  descricao: string;
  dataPrevisao: string;
  dataTermino: string;
  statusId: string;
  status: Status;
}
