import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Tarefa } from '../models/tarefa';
import { TarefaService } from '../tarefas_service';

@Component({
  selector: 'app-detalhe-tarefa',
  templateUrl: './detalhe-tarefa.component.html',
  styles: [],
})
export class DetalheTarefaComponent {
  @Input()
  tarefa: Tarefa;

  @Output()
  statusConcluido: EventEmitter<any> = new EventEmitter();

  constructor(
    private tarefaService: TarefaService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    };
  }

  concluirTarefa() {
    if (this.tarefa.id) {
      this.tarefaService.concluirTarefa(this.tarefa).subscribe(() => {
        setTimeout(() => {this.router.navigateByUrl('/tarefas');}, 1000);
      });
    }
  }

  desenvolverTarefa() {
    if (this.tarefa.id) {
      this.tarefaService.desenvolverTarefa(this.tarefa).subscribe(() => {
        setTimeout(() => {this.router.navigateByUrl('/tarefas');}, 1000);
      });
    }
  }
}
