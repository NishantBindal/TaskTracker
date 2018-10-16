import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from '../shared/shared.module';
import { LoginComponent } from './login/login.component';
import { BoardComponent } from './board/board.component';
import { SprintComponent } from './sprint/sprint.component';
import { SprintTemplateComponent } from './sprint-template/sprint-template.component';
import { CoreModule } from 'src/core/core.module';
import { SprintWizardComponent } from './sprint-wizard/sprint-wizard.component';
import { SprintWizardStepDetailsComponent } from './sprint-wizard-step-details/sprint-wizard-step-details.component';
import { SprintWizardStepTeamMembersComponent } from './sprint-wizard-step-team-members/sprint-wizard-step-team-members.component';
import { EventTemplateComponent } from 'src/core/components/event-template/event-template.component';

@NgModule({
  imports: [SharedModule, CoreModule],
  declarations: [
    AppComponent,
    LoginComponent,
    BoardComponent,
    SprintTemplateComponent,
    SprintComponent,
    SprintWizardComponent,
    SprintWizardStepDetailsComponent,
    SprintWizardStepTeamMembersComponent,
    EventTemplateComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
