declare function require(name: string);
const axios = require('axios');
import { Injectable } from '@angular/core';
import { ValidatorFn, FormControl, AsyncValidatorFn } from '@angular/forms';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {
  async MakeRequest(params: {
    Method: string;
    URL: string;
    Data?: any;
    Headers?: any;
  }): Promise<any> {
    const requestParams = {
      url: params.URL,
      method: params.Method,
      headers: params.Headers,
      data: params.Data
    };
    return (await axios.request(requestParams))['data'];
  }

  Wait(timeoutInMs: number): Promise<void> {
    return new Promise(resolve => {
      setTimeout(resolve, timeoutInMs);
    });
  }

  CreateControl(
    labelName: string,
    formValidators: {
      validator: ValidatorFn;
      validatorName: string;
      errorMessage: string;
    }[],
    // asyncValidators?: {
    //   validator: AsyncValidatorFn;
    //   validatorName: string;
    //   errorMessage: string;
    // }[],
    formState?: any
  ): {
    LabelName: string;
    GetValue: () => string;
    Control: FormControl;
    ErrorMessage: () => string;
  } {
    const formControl = new FormControl(
      formState,
      formValidators.map(a => a.validator)
      // asyncValidators.map(a => a.validator)
    );
    // const validators = formValidators.concat(asyncValidators);
    return {
      LabelName: labelName,
      GetValue: () => formControl.value,
      Control: formControl,
      ErrorMessage: () =>
        this.getErrorMessage(
          formControl,
          formValidators.map(a => {
            return { validator: a.validatorName, errorMessage: a.errorMessage };
          })
        )
    };
  }

  private getErrorMessage(
    formControl: FormControl,
    validations: { validator: string; errorMessage: string }[]
  ): string {
    if (!formControl.touched && formControl.errors) {
      return null;
    }
    for (const validatorName in formControl.errors) {
      if (formControl.errors.hasOwnProperty(validatorName)) {
        const validation = validations.find(
          a => a.validator.toLowerCase() === validatorName
        );
        return validation ? validation.errorMessage : null;
      }
    }
  }

  weekendDateFilter(d: Date): boolean {
    const day = moment(d).weekday();
    return day !== 0 && day !== 6;
  }
}
