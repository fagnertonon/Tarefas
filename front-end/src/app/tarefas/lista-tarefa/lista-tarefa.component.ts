import { Component } from '@angular/core';
import { Tarefa } from '../models/tarefa';
import { TarefaService } from '../tarefas_service';

@Component({
  selector: 'app-lista-tarefa',
  templateUrl: './lista-tarefa.component.html',
  styles: [],
})
export class ListaTarefaComponent {
  constructor(private tarefaService: TarefaService) {}

  public tarefas!: Tarefa[];

  ngOnInit() {
    this.tarefaService.obterTarefas().subscribe((tarefas) => {
      this.tarefas = tarefas;
    });
  }
  filtrarAFazer(tarefa: Tarefa) {
    return tarefa.status.descricao == 'A Fazer';
  }
  filtrarEmDesenvolvimento(tarefa: Tarefa) {
    return tarefa.status.descricao == 'Em Desenvolvimento';
  }
  filtrarConcluido(tarefa: Tarefa) {
    return tarefa.status.descricao == 'Concluído';
  }
}
