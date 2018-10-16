import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintWizardComponent } from './sprint-wizard.component';

describe('SprintWizardComponent', () => {
  let component: SprintWizardComponent;
  let fixture: ComponentFixture<SprintWizardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SprintWizardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SprintWizardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
