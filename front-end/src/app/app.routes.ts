import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './navegacao/home/home.component';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';

export const rootRouterConfig: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },

  { path: 'home', component: HomeComponent },
  {
    path: 'tarefas',
    loadChildren: () =>
      import('./tarefas/tarefa.module').then((x) => x.TarefaModule),
  },

  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(rootRouterConfig, {
      enableTracing: false,
      onSameUrlNavigation: 'reload',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
