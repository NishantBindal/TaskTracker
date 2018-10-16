import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialDesignModule } from './material.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { RouteModule } from 'src/app/app-routing-module';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  exports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialDesignModule,
    RouteModule,
    RouterModule
  ],
  providers: []
})
export class SharedModule {}
