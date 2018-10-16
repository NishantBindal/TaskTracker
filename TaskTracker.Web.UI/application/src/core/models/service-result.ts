export class ServiceResult<T> {
  isConnectionSuccessful: boolean;
  isSuccessful: boolean;
  result: T;
  errorMessage: string;

  constructor(
    isSuccessful: boolean = true,
    result: T,
    errorMessage: string = ''
  ) {
    this.isConnectionSuccessful = false;
    this.isSuccessful = isSuccessful;
    this.result = result;
    this.errorMessage = errorMessage;
  }
}
