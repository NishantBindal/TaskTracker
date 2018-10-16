import { Injectable } from '@angular/core';
import { Board } from 'src/core/models/board.model';
import { Sprint } from 'src/core/models/sprint.model';
import { ResponseService } from './responses.service';
import { ServiceResult } from '../models/service-result';
import { URL } from '../enums/url.enum';
import { UtilityService } from './utility.service';
import { EnvironmentConfigurationService } from './configuration.service';
import { LoggerService } from './logger.service';
import { MockSprints, MockBoards, MockTeamMembers } from 'src/mock/mock-data';
import { TeamMember } from '../models/team-member';
import { Login } from 'src/models/login.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(
    private logger: LoggerService,
    private responses: ResponseService,
    private utility: UtilityService,
    private configuration: EnvironmentConfigurationService
  ) {}
  private BaseApiURL = this.configuration.EnvConfiguration.API_URL;
  public IsServiceAvailable?: boolean;
  private MaxRetryLimit = 2;

  async TestServiceConnection(): Promise<ServiceResult<boolean>> {
    try {
      return await this.Get(URL.Test);
    } catch (error) {
      this.logger.Error(error);
      return this.responses.FailureBoolResult(error.message);
    }
  }

  async JiraAuth(url: string): Promise<ServiceResult<boolean>> {
    try {
      return await this.Get(URL.JiraAuth, {
        queryVariables: {
          url: url
        }
      });
    } catch (error) {
      this.logger.Error(error);
      return this.responses.FailureBoolResult(error.message);
    }
  }

  async Authenticate(loginModel: Login): Promise<ServiceResult<boolean>> {
    try {
      return await this.Get(URL.Authenticate, {
        queryVariables: {
          emailAddress: loginModel.EmailAddress,
          password: loginModel.Password,
          url: loginModel.JiraURL
        }
      });
    } catch (error) {
      this.logger.Error(error);
      return this.responses.FailureBoolResult(error.message);
    }
  }

  async GetBoards(organizationId: string): Promise<ServiceResult<Board[]>> {
    try {
      // await Wait(5000);
      return this.responses.SuccessResult(MockBoards);
      return await this.Get(URL.Board, {
        queryVariables: {
          id: organizationId
        }
      });
    } catch (error) {
      this.logger.Error(error);
      return this.responses.FailureNullResult(error.message);
    }
  }

  async GetSprints(boardId: number): Promise<ServiceResult<Sprint[]>> {
    try {
      // await Wait(5000);
      return this.responses.SuccessResult(MockSprints);
      return await this.Get(URL.Sprint, {
        queryVariables: {
          id: boardId
        }
      });
    } catch (error) {
      this.logger.Error(error);
      return this.responses.FailureNullResult(error.message);
    }
  }

  async GetTeamMembers(): Promise<ServiceResult<TeamMember[]>> {
    try {
      // await Wait(5000);
      return this.responses.SuccessResult(MockTeamMembers);
      return await this.Get(URL.TeamMembers);
    } catch (error) {
      this.logger.Error(error);
      return this.responses.FailureNullResult(error.message);
    }
  }

  //#region :: Base Methods ::

  private async Get(
    actionName: string,
    params: {
      queryVariables?: any;
      retryCount?: number;
    } = { retryCount: 1 },
    IncludeHeader: boolean = true
  ): Promise<any> {
    if (!params.retryCount) {
      params.retryCount = 1;
    }
    if (params.retryCount > this.MaxRetryLimit) {
      throw new Error(`Maximum retry count exceeded`);
    }
    let url = `${this.BaseApiURL}/${actionName}`;
    if (params.queryVariables != null) {
      let variables = '/?';
      for (const key in params.queryVariables) {
        if (params.queryVariables.hasOwnProperty(key)) {
          variables += `${key}=${params.queryVariables[key]}&`;
        }
      }
      url += variables;
    }
    try {
      // console.log(JSON.stringify(params) + ' ' + actionName);
      return await this.utility.MakeRequest({
        Method: 'GET',
        URL: url,
        Headers: {
          // Authorization: IncludeHeader && (await this.AuthorizationToken)
        }
      });
    } catch (error) {
      // if (error.response && error.response.status === 401) {
      //   this._authorizationToken = null;
      //   console.log(`Unauthorized Access, refreshing token....`);
      //   await this.AuthorizationToken;
      // }
      if (error.response && error.response.status === 500) {
        throw new Error(`${error} - `);
      }
      console.log(`${actionName} - Retry - ${params.retryCount}`);
      return this.Get(
        actionName,
        {
          queryVariables: params.queryVariables,
          retryCount: ++params.retryCount
        },
        IncludeHeader
      );
    }
  }

  private async Post(
    actionName: string,
    data?: any,
    retryCount?: number
  ): Promise<any> {
    if (!retryCount) {
      retryCount = 1;
    }
    if (retryCount > this.MaxRetryLimit) {
      throw new Error(`Maximum retry count exceeded`);
    }
    try {
      return await this.utility.MakeRequest({
        Method: 'POST',
        URL: `${this.BaseApiURL}/${actionName}`,
        Headers: {
          // Authorization: await this.AuthorizationToken
        },
        Data: data
      });
    } catch (error) {
      // if (error.response && error.response.status === 401) {
      //   this._authorizationToken = null;
      //   console.log(`Unauthorized Access, refreshing token....`);
      //   await this.AuthorizationToken;
      // }
      if (error.response && error.response.status === 500) {
        throw new Error(`${error} - `);
      }
      console.log(`${actionName} - Retry - ${retryCount}`);
      return this.Post(actionName, data, ++retryCount);
    }
  }

  //#endregion
}
