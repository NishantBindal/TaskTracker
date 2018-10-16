import { Messages } from '../enums/messages.enum';

export class ResolvedResult<T> {
  Result: T;
  ResultMessage: Messages;
  Message: string;

  constructor(result: T, resultMessage: Messages, message: string) {
    this.Result = result;
    this.ResultMessage = resultMessage;
    this.Message = message;
  }
}
