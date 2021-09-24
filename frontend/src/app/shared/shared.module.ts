import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { MaterialModule } from './material.module';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SpinnerComponent } from './component/spinner/spinner.component';
import { NoResultComponent } from './component/no-result/no-result.component';
import { SelectComponent } from './component/select/select.component';
import { PaginationComponent } from './component/pagination/pagination.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgbModule,
    FontAwesomeModule,
  ],
  declarations: [
    NoResultComponent,
    SpinnerComponent,
    SelectComponent,
    PaginationComponent,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,

    MaterialModule,

    NgbModule,
    FontAwesomeModule,
    SpinnerComponent,
    NoResultComponent,
    SelectComponent,
    NoResultComponent,
    PaginationComponent,
  ],
})
export class SharedModule {}
