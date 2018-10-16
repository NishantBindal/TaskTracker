import { RouterModule, Routes, Router } from '@angular/router';
import { NgModule } from '@angular/core';

import { LoginComponent } from './login/login.component';
import { BoardComponent } from './board/board.component';
import { SprintComponent } from './sprint/sprint.component';
import { SprintWizardComponent } from './sprint-wizard/sprint-wizard.component';

const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'boards', component: BoardComponent },
  { path: 'boards/:id/sprints', component: SprintComponent },
  { path: 'boards/:id/sprints/new', component: SprintWizardComponent },
  { path: '', redirectTo: 'boards', pathMatch: 'full' },
  { path: '**', redirectTo: 'boards', pathMatch: 'full' }
  // {path: 'users/:id', component:}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(appRoutes, { enableTracing: false })],
  exports: [],
  providers: []
})
export class RouteModule {}
