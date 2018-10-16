import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintWizardStepDetailsComponent } from './sprint-wizard-step-details.component';

describe('SprintWizardStepDetailsComponent', () => {
  let component: SprintWizardStepDetailsComponent;
  let fixture: ComponentFixture<SprintWizardStepDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SprintWizardStepDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SprintWizardStepDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
