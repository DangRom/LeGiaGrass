import { Component, OnInit }    from '@angular/core';
import { CompanyService }          from './company.service';

@Component({
  selector: 'pc-companies-page',
  templateUrl: './app/components/companies/templates/companies-page.component.html'
})
export class CompaniesPageComponent implements OnInit {
  loading = false;

  constructor(private companyService: CompanyService) {
  }

  ngOnInit(): void {
    this.loading = true;
    this.companyService.init()
      .then(() => {
        this.loading = false;
      });
  }



  save(): void {
      if (confirm(`Are you sure you want to save "${this.companyService.getCurrent().name}" changes`)) {
      this.loading = true;
      this.companyService.save()
        .then(() => {
          this.loading = false;
        });
    }
  }
  
}