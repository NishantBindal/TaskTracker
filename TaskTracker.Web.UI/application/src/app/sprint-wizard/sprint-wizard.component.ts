import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {
  FormGroup,
  Validators,
  FormControl,
  ValidatorFn,
  AbstractControl,
  FormBuilder,
  AsyncValidatorFn
} from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE
} from '@angular/material/core';
import { ApiService } from 'src/core/services/api.service';
import { LoggerService } from 'src/core/services/logger.service';
import { UtilityService } from 'src/core/services/utility.service';
import { ValidatorNames } from 'src/core/enums/validator-names.enum';
import * as moment from 'moment';
import { TeamMember } from 'src/core/models/team-member';
import { ENTER, COMMA } from '@angular/cdk/keycodes';
import { Observable } from 'rxjs';
import { MatAutocompleteSelectedEvent } from '@angular/material';
import { startWith, map } from 'rxjs/operators';
import { ServiceResultResolverService } from 'src/core/services/resolver.service';
import { Messages } from 'src/core/enums/messages.enum';
import { MemberAvailability } from 'src/core/models/member-availability.model';
import * as _ from 'lodash';

@Component({
  selector: 'app-sprint-wizard',
  templateUrl: './sprint-wizard.component.html',
  styleUrls: ['./sprint-wizard.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE]
    },
    {
      provide: MAT_DATE_FORMATS,
      useValue: {
        parse: {
          dateInput: 'LL'
        },
        display: {
          dateInput: 'LL',
          monthYearLabel: 'MMM YYYY',
          dateA11yLabel: 'LL',
          monthYearA11yLabel: 'MMMM YYYY'
        }
      }
    }
  ]
})
export class SprintWizardComponent implements OnInit {
  sprintDetailsFormGroup: FormGroup;

  teamDetailsFormGroup: FormGroup;

  availabilityFormGroup: FormGroup;

  SprintTimeline: Date[];
  TimelineEvents: MemberAvailability[] = [];
  Dates: string[];
  MemberCollection: Observable<TeamMember[]>;
  Members: TeamMember[];
  SelectedMembers: TeamMember[] = [];
  SeparatorKeysCodes: number[] = [ENTER, COMMA];
  TeamAvailabilityModel: {
    Member: TeamMember;
    AvailabilityData: MemberAvailability[];
  }[] = [];

  @ViewChild('memberInput')
  memberInput: ElementRef<HTMLInputElement>;

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
  TeamMemberSelector = this.utility.CreateControl('Members', []);

  constructor(
    private apiService: ApiService,
    private logger: LoggerService,
    private utility: UtilityService,
    private resolver: ServiceResultResolverService,
    private formBuilder: FormBuilder
  ) {
    this.sprintDetailsFormGroup = new FormGroup({
      SprintName: this.SprintName.Control,
      SprintStartDate: this.SprintStartDate.Control,
      SprintEndDate: this.SprintEndDate.Control
    });
    this.teamDetailsFormGroup = this.formBuilder.group(
      {
        TeamMemberSelector: ['', []]
      },
      this.ValidateSelectedMembers
    );
    this.availabilityFormGroup = new FormGroup({});
  }
  ngOnInit() {
    this.Initialize().then(() => {
      return;
    });
  }

  dateFilter = d => this.utility.weekendDateFilter(d);

  async Initialize() {
    const result = this.resolver.Resolve(
      await this.apiService.GetTeamMembers()
    );
    switch (result.ResultMessage) {
      case Messages.Success:
        this.Members = result.Result.sort((a, b) => {
          if (a.Name < b.Name) {
            return -1;
          }
          if (a.Name > b.Name) {
            return 1;
          }
          return 0;
        });
        this.SprintName.Control.setValue('Sprint 1');
        this.SelectedMembers = this.Members;
        this.MemberCollection = this.TeamMemberSelector.Control.valueChanges.pipe(
          startWith<string | TeamMember>(''),
          map(value => {
            if (value === null) {
              return undefined;
            }
            return typeof value === 'string' ? value : value.Name;
          }),
          map(name => {
            const list = this.Members.filter(
              a => this.SelectedMembers.indexOf(a) !== 0
            );
            return name
              ? list.filter(
                  member => member.Name.toLowerCase().indexOf(name) === 0
                )
              : list.slice();
          })
        );
        break;
    }
  }

  DeselectMember(member: TeamMember) {
    this.SelectedMembers.splice(this.SelectedMembers.indexOf(member), 1);
  }

  OptionSelected(event: MatAutocompleteSelectedEvent): void {
    if (this.SelectedMembers.indexOf(event.option.value) === -1) {
      this.SelectedMembers.push(event.option.value);
    }
    this.memberInput.nativeElement.value = '';
    this.TeamMemberSelector.Control.setValue(null);
  }

  DisplayMemberName(member?: TeamMember): string | undefined {
    return member ? member.Name : undefined;
  }

  ValidateSelectedMembers(formGroup: FormGroup) {
    this.logger.Debug(this.SelectedMembers);
    this.logger.Debug(this.TeamMemberSelector.Control.status);
    this.logger.Debug(this.teamDetailsFormGroup);
    if (this.SelectedMembers.length === 0) {
      return {
        TeamMemberSelector: { valid: false }
      };
    } else {
      return null;
    }
    return this.SelectedMembers.length === 0
      ? { TeamMemberSelector: { valid: false } }
      : null;
  }

  SetSprintTimeline() {
    const startDate = moment(this.SprintStartDate.GetValue());
    const endDate = moment(this.SprintEndDate.GetValue());

    let currentDate = startDate;
    while (currentDate <= endDate) {
      const event: MemberAvailability = new MemberAvailability();
      event.Date = currentDate.toDate();
      event.AvailableHours = 7;
      event.IsWeekend = !this.dateFilter(currentDate);
      this.TimelineEvents.push(event);
      currentDate = currentDate.add(1, 'day');
    }
    this.Dates = this.TimelineEvents.map(
      a => `${a.Date.getDate()}_${a.Date.getMonth()}`
    );
  }

  SetSelectedMembers() {
    this.TeamAvailabilityModel = [];
    for (const member of this.SelectedMembers) {
      const events = _.cloneDeep(this.TimelineEvents);
      events.forEach(a => {
        a.MemberID = member.ID;
      });
      this.TeamAvailabilityModel.push({
        Member: member,
        AvailabilityData: events
      });
    }

    this.logger.Debug(this.TeamAvailabilityModel);
    this.SetTeamAvailabilityFormGroup();
  }

  SetTeamAvailabilityFormGroup() {
    this.TeamAvailabilityModel.forEach(modelElement => {
      modelElement.AvailabilityData.forEach(availability => {
        if (availability.IsWeekend) {
          return;
        }
        this.availabilityFormGroup.addControl(
          `${modelElement.Member.ID}_${availability.Date.getDate()}`,
          this.utility.CreateControl(
            'Hours',
            [
              {
                validator: Validators.required,
                validatorName: ValidatorNames.required,
                errorMessage: 'Hours Required'
              }
            ],
            availability.AvailableHours
          ).Control
        );
      });
    });
    this.logger.Debug(this.availabilityFormGroup);
  }
}
