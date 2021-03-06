import { NgModule } from '@angular/core';
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatCardModule,
  MatCheckboxModule,
  MatFormFieldModule,
  MatInputModule,
  MatNativeDateModule,
  MatRippleModule,
  MatSnackBarModule,
  MatExpansionModule,
  MatStepperModule,
  MatDatepickerModule,
  MatChipsModule,
  MatIconModule,
  MatTableModule
} from '@angular/material';
import { OverlayModule } from '@angular/cdk/overlay';
import { PlatformModule } from '@angular/cdk/platform';
import { ObserversModule } from '@angular/cdk/observers';

@NgModule({
  imports: [
    MatAutocompleteModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatNativeDateModule,
    ObserversModule,
    OverlayModule,
    PlatformModule,
    MatSnackBarModule,
    MatStepperModule,
    MatDatepickerModule,
    MatChipsModule,
    MatIconModule,
    MatTableModule
  ],
  exports: [
    MatAutocompleteModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatNativeDateModule,
    ObserversModule,
    OverlayModule,
    PlatformModule,
    MatSnackBarModule,
    MatExpansionModule,
    MatStepperModule,
    MatDatepickerModule,
    MatChipsModule,
    MatIconModule,
    MatTableModule
  ]
})
export class MaterialDesignModule {}
