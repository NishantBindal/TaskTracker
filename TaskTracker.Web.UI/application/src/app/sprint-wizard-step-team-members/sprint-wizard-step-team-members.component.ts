import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  Output
} from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UtilityService } from 'src/core/services/utility.service';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { TeamMember } from 'src/core/models/team-member';
import { ApiService } from 'src/core/services/api.service';
import { ServiceResultResolverService } from 'src/core/services/resolver.service';
import { Messages } from 'src/core/enums/messages.enum';
import { LoggerService } from 'src/core/services/logger.service';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import {
  MatChipInputEvent,
  MatAutocompleteSelectedEvent
} from '@angular/material';

@Component({
  selector: 'app-sprint-wizard-step-team-members',
  templateUrl: './sprint-wizard-step-team-members.component.html',
  styleUrls: ['./sprint-wizard-step-team-members.component.css']
})
export class SprintWizardStepTeamMembersComponent implements OnInit {
  teamDetailsFormGroup: FormGroup;
  TeamMemberSelector = this.utility.CreateControl('Member Name', []);

  MemberCollection: Observable<TeamMember[]>;
  Members: TeamMember[];
  SelectedMembers: TeamMember[] = [];
  SeparatorKeysCodes: number[] = [ENTER, COMMA];

  @ViewChild('memberInput')
  memberInput: ElementRef<HTMLInputElement>;

  constructor(
    private utility: UtilityService,
    private apiService: ApiService,
    private resolver: ServiceResultResolverService,
    private logger: LoggerService
  ) {
    this.teamDetailsFormGroup = new FormGroup({
      TeamMemberSelector: this.TeamMemberSelector.Control
    });
  }

  ngOnInit() {
    this.Initialize().then(() => {
      return;
    });
  }

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
    this.logger.Debug(`Deselect Member - ${member}`);
    this.SelectedMembers.splice(this.SelectedMembers.indexOf(member), 1);
  }

  OptionSelected(event: MatAutocompleteSelectedEvent): void {
    this.logger.Debug(event.option.value);
    if (this.SelectedMembers.indexOf(event.option.value) === -1) {
      this.SelectedMembers.push(event.option.value);
    }
    this.memberInput.nativeElement.value = '';
    this.TeamMemberSelector.Control.setValue(null);
  }

  DisplayMemberName(member?: TeamMember): string | undefined {
    return member ? member.Name : undefined;
  }
}
