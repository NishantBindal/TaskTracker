import { Injectable } from '@angular/core';
import { ServiceResult } from '../models/service-result';
import { ResolvedResult } from '../models/resolved-result';
import { Messages } from '../enums/messages.enum';

@Injectable({
  providedIn: 'root'
})
export class ServiceResultResolverService {
  Resolve<T>(serviceResult: ServiceResult<T>): ResolvedResult<T> {
    const resolvedResult = new ResolvedResult<T>(
      serviceResult.result,
      Messages.FailedConnection,
      ''
    );
    // if (!serviceResponse.IsConnectionSuccessful) {
    //   ApiService.IsServiceAvailable = false;
    //   return serviceResult;
    // }
    // ApiService.IsServiceAvailable = true;
    resolvedResult.Message = serviceResult.errorMessage;
    resolvedResult.ResultMessage = serviceResult.isSuccessful
      ? Messages.Success
      : Messages.Failed;
    return resolvedResult;
  }
}
