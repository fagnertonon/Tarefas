import { NgModule } from "@angular/core";
import { Router, RouterModule, Routes } from "@angular/router";
import { CadastrarTarefaComponent } from "./cadastrar-tarefa/cadastrar-tarefa.component";
import { EditarTarefaComponent } from "./editar-tarefa/editar-tarefa.component";
import { ExcluirTarefaComponent } from "./excluir-tarefa/excluir-tarefa.component";
import { ListaTarefaComponent } from "./lista-tarefa/lista-tarefa.component";
import { TarefaAppComponent } from "./tarefa.app.component";

const tarefaRouterConfig: Routes = [
  {
    path: "",
    component: TarefaAppComponent,
    children: [
      { path: "", component: ListaTarefaComponent },
      { path: "editar/:id", component: EditarTarefaComponent },
      { path: "cadastrar", component: CadastrarTarefaComponent },
      { path: "excluir/:id", component: ExcluirTarefaComponent },
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(tarefaRouterConfig)],
  exports: [RouterModule],
})
export class TarefaRoutingModule {}
