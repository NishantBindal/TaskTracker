import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  public Switch = true;

  public Debug(message: any): void {
    if (!this.Switch) {
      return;
    }
    if (message === null || message === undefined) {
      console.log(message);
      return;
    }
    if (message.constructor.name === 'Function') {
      return;
    } else {
      if (
        message.constructor.name === 'String' ||
        message.constructor.name === 'Number'
      ) {
        console.log(message);
      } else {
        console.dir(message);
      }
    }
  }

  public Error(error: Error): void {
    if (!this.Switch) {
      return;
    }
    console.log('Error Occurred - ', error, error.message);
  }
}
