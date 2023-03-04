import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ListaTarefaComponent } from './lista-tarefa/lista-tarefa.component';
import { TarefaService } from './tarefas_service';
import { TarefaRoutingModule } from './tarefa.route';
import { CadastrarTarefaComponent } from './cadastrar-tarefa/cadastrar-tarefa.component';
import { EditarTarefaComponent } from './editar-tarefa/editar-tarefa.component';
import { DetalheTarefaComponent } from './detalhe-tarefa/detalhe-tarefa.component';
import { TarefaAppComponent } from './tarefa.app.component';
import { ExcluirTarefaComponent } from './excluir-tarefa/excluir-tarefa.component';
import { FiltroTarefaPipe } from './Pipe/tarefa.pipe';
@NgModule({
  declarations: [
    TarefaAppComponent,
    ListaTarefaComponent,
    CadastrarTarefaComponent,
    EditarTarefaComponent,
    DetalheTarefaComponent,
    ExcluirTarefaComponent,
    FiltroTarefaPipe,
  ],
  imports: [
    CommonModule,
    TarefaRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [TarefaService],
  exports: [],
})
export class TarefaModule {}
