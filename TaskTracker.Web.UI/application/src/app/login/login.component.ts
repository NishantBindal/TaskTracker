import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/core/services/api.service';
import { LoggerService } from 'src/core/services/logger.service';
import { ServiceResultResolverService } from 'src/core/services/resolver.service';
import { UtilityService } from 'src/core/services/utility.service';
import { ValidatorNames } from 'src/core/enums/validator-names.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //#region :: Form Controls ::

  JiraURL = this.utility.CreateControl('Jira URL', [
    {
      validator: Validators.required,
      validatorName: 'required',
      errorMessage: 'Jira URL is required'
    },
    {
      validator: Validators.maxLength(250),
      validatorName: 'maxLength',
      errorMessage: 'Jira URL cannot be more than 250 characters'
    }
  ]);

  EmailAddress = this.utility.CreateControl('Email Address', [
    {
      validator: Validators.required,
      validatorName: 'required',
      errorMessage: 'Email Address is required'
    },
    {
      validator: Validators.email,
      validatorName: ValidatorNames.email,
      errorMessage: 'Invalid Email Address'
    },
    {
      validator: Validators.maxLength(250),
      validatorName: 'maxLength',
      errorMessage: 'EmailAddress cannot be more than 250 characters'
    }
  ]);

  Password = this.utility.CreateControl('Password', [
    {
      validator: Validators.required,
      validatorName: 'required',
      errorMessage: 'Password is required'
    },
    {
      validator: Validators.maxLength(250),
      validatorName: 'maxLength',
      errorMessage: 'Password cannot be more than 250 characters'
    }
  ]);

  //#endregion

  loginForm: FormGroup;
  messageText: string;
  colorClass: string;
  ngOnInit() {}

  constructor(
    private apiService: ApiService,
    private logger: LoggerService,
    private resolver: ServiceResultResolverService,
    private utility: UtilityService
  ) {
    this.loginForm = new FormGroup({
      JiraURL: this.JiraURL.Control,
      EmailAddress: this.EmailAddress.Control,
      Password: this.Password.Control
    });
  }

  async login(): Promise<void> {
    const result = this.resolver.Resolve(
      await this.apiService.Authenticate({
        EmailAddress: this.EmailAddress.GetValue(),
        Password: this.Password.GetValue(),
        JiraURL: this.JiraURL.GetValue()
      })
    );
    this.logger.Debug(result);
  }

  AppendText() {
    if (
      this.JiraURL.GetValue() === '' ||
      this.JiraURL.GetValue().includes('.atlassian.net')
    ) {
      return;
    }
    this.JiraURL.Control.setValue(this.JiraURL.GetValue() + '.atlassian.net');
  }
}
