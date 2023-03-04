import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Tarefa } from '../models/tarefa';
import { TarefaService } from '../tarefas_service';
// import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-excluir-tarefa',
  templateUrl: './excluir-tarefa.component.html',
  styleUrls: ['./excluir-tarefa.component.css'],
})
export class ExcluirTarefaComponent implements OnInit {
  tarefa: Tarefa = new Tarefa();
  
  constructor(
    private tarefaService: TarefaService,
    private router: Router,
    private route: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.tarefaService.obterTarefasPorId(params["id"]).subscribe((tarefa) => {
        this.tarefa = tarefa;
        console.log(this.tarefa)
      });
    });
  }

  excluirTarefa() {
    if (this.tarefa.id) {
      this.tarefaService.excluir(this.tarefa.id).subscribe(() => {
        this.router.navigate(['/tarefas']);
      });
    }
  } 

  cancelar() {
    this.router.navigate(['/tarefas']);
  }
}
