import { Injectable } from '@angular/core';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition
} from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {
  constructor(private snackBar: MatSnackBar) {}

  public Show(
    message: string,
    options: {
      action?: string;
      duration?: number;
      position?: {
        horizontalPosition: MatSnackBarHorizontalPosition;
        verticalPosition: MatSnackBarVerticalPosition;
      };
    } = {
      action: 'Dismiss',
      duration: 2000,
      position: {
        horizontalPosition: 'right',
        verticalPosition: 'top'
      }
    }
  ): void {
    if (!options.action) {
      options.action = 'Dismiss';
    }
    if (!options.duration) {
      options.duration = 2000;
    }
    if (!options.position) {
      options.position = {
        horizontalPosition: 'right',
        verticalPosition: 'top'
      };
    }
    if (!options.position.horizontalPosition) {
      options.position.horizontalPosition = 'right';
    }
    if (!options.position.verticalPosition) {
      options.position.verticalPosition = 'top';
    }
    this.snackBar.open(message, options.action, {
      horizontalPosition: options.position.horizontalPosition,
      verticalPosition: options.position.verticalPosition,
      duration: options.duration
    });
  }
}
