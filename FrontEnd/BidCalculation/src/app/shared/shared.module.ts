import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { MaterialModule } from '../material/material.module';
import { SpinnerComponent } from './spinner/spinner.component';

@NgModule({
  declarations: [
    HeaderComponent,
    SpinnerComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    HeaderComponent,
    SpinnerComponent
  ]
})
export class SharedModule { }
