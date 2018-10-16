import { Component, OnInit, Input, Output } from '@angular/core';
import { UtilityService } from 'src/core/services/utility.service';
import { Validators } from '@angular/forms';
import { ValidatorNames } from 'src/core/enums/validator-names.enum';

@Component({
  selector: 'app-event-template',
  templateUrl: './event-template.component.html',
  styleUrls: ['./event-template.component.css']
})
export class EventTemplateComponent implements OnInit {
  @Input()
  event: Event;

  Hours = this.utility.CreateControl('Hours', [
    {
      validator: Validators.required,
      validatorName: ValidatorNames.required,
      errorMessage: 'Hours cannot be empty'
    }
  ]);

  constructor(private utility: UtilityService) {}

  ngOnInit() {}
}
