import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintWizardStepTeamAvaialabilityComponent } from './sprint-wizard-step-team-avaialability.component';

describe('SprintWizardStepTeamAvaialabilityComponent', () => {
  let component: SprintWizardStepTeamAvaialabilityComponent;
  let fixture: ComponentFixture<SprintWizardStepTeamAvaialabilityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SprintWizardStepTeamAvaialabilityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SprintWizardStepTeamAvaialabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
