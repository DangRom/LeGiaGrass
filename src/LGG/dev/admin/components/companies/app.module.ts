import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';

import { CompaniesPageComponent } from './companies-page.component';

import { CompanyService } from './company.service';

import { CompanyRepository } from '../../repositories/company.repository';

import { TruncatePipe } from '../../pipes/truncate.pipe';
import { LoaderComponent } from '../shared/loader/loader.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  declarations: [
    AppComponent,
      CompaniesPageComponent,
    TruncatePipe,
    LoaderComponent
  ],
  providers: [
      CompanyRepository,
      CompanyService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }