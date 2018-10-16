import { Component, OnInit, Output } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import { UtilityService } from 'src/core/services/utility.service';
import { ValidatorNames } from 'src/core/enums/validator-names.enum';
import * as moment from 'moment';

@Component({
  selector: 'app-sprint-wizard-step-details',
  templateUrl: './sprint-wizard-step-details.component.html',
  styleUrls: ['./sprint-wizard-step-details.component.css']
})
export class SprintWizardStepDetailsComponent implements OnInit {
  sprintDetailsFormGroup: FormGroup;
  SprintName = this.utility.CreateControl('Name', [
    {
      validator: Validators.required,
      validatorName: ValidatorNames.required,
      errorMessage: 'Sprint name is required'
    },
    {
      validator: Validators.maxLength(100),
      validatorName: ValidatorNames.maxLength,
      errorMessage: 'Sprint name should not be longer than 100 characters'
    }
  ]);

  SprintStartDate = this.utility.CreateControl(
    'Start Date',
    [
      {
        validator: Validators.required,
        validatorName: ValidatorNames.required,
        errorMessage: 'Sprint should have a start date'
      }
    ],
    moment()
  );

  SprintEndDate = this.utility.CreateControl(
    'End Date',
    [
      {
        validator: Validators.required,
        validatorName: ValidatorNames.required,
        errorMessage: 'Sprint should have an end date'
      }
    ],
    moment().add(2, 'w')
  );

  constructor(private utility: UtilityService) {
    this.sprintDetailsFormGroup = new FormGroup({
      SprintName: this.SprintName.Control,
      SprintStartDate: this.SprintStartDate.Control,
      SprintEndDate: this.SprintEndDate.Control
    });
  }

  dateFilter = d => this.utility.weekendDateFilter(d);

  ngOnInit() {}
}
