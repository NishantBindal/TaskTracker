import { Injectable } from '@angular/core';

declare function require(name: string);
const configuration = require('../config/config.json');

@Injectable({
  providedIn: 'root'
})
export class EnvironmentConfigurationService {
  private _envConfiguration: { [key: string]: any };
  get EnvConfiguration(): { [key: string]: any } {
    if (!this._envConfiguration) {
      this.SetEnvConfiguration();
    }
    return this._envConfiguration;
  }

  SetEnvConfiguration(env: string = 'DEV') {
    this._envConfiguration = {};
    this.EnvConfigure(configuration[env]);
  }

  private EnvConfigure(envConfig: any) {
    // tslint:disable-next-line:forin
    for (const configKey in envConfig) {
      if (!envConfig.hasOwnProperty(configKey)) {
        return;
      }
      if (envConfig[configKey].constructor.name === 'String') {
        this._envConfiguration[configKey] = envConfig[configKey];
        continue;
      }
      this.EnvConfigure(envConfig[configKey]);
    }
  }
}
