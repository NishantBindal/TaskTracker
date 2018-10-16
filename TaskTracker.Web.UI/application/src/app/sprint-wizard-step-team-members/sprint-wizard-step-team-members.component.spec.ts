import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintWizardStepTeamMembersComponent } from './sprint-wizard-step-team-members.component';

describe('SprintWizardStepTeamMembersComponent', () => {
  let component: SprintWizardStepTeamMembersComponent;
  let fixture: ComponentFixture<SprintWizardStepTeamMembersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SprintWizardStepTeamMembersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SprintWizardStepTeamMembersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
