import { Injectable } from '@angular/core';
import { ServiceResult } from '../models/service-result';

@Injectable({
  providedIn: 'root'
})
export class ResponseService {
  SuccessResult<T>(result: T): ServiceResult<T> {
    return new ServiceResult<T>(true, result);
  }
  SuccessBoolResult(result: boolean = true): ServiceResult<boolean> {
    return new ServiceResult<boolean>(true, result);
  }

  SuccessNullResult<T>(message: string): ServiceResult<T> {
    return new ServiceResult<T>(true, null, message);
  }

  FailureResult<T>(
    result: T,
    errorMessage: string = 'Unknown Error'
  ): ServiceResult<T> {
    return new ServiceResult<T>(false, result, errorMessage);
  }

  FailureNullResult<T>(
    errorMessage: string = 'Unknown Error'
  ): ServiceResult<T> {
    return new ServiceResult<T>(false, null, errorMessage);
  }

  FailureBoolResult(
    errorMessage: string = 'Unknown Error'
  ): ServiceResult<boolean> {
    return new ServiceResult<boolean>(false, false, errorMessage);
  }
}
