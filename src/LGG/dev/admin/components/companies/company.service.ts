import { Injectable } from '@angular/core';
import { CompanyRepository } from '../../repositories/company.repository';
import { Company } from '../../models/company';
import 'rxjs/add/operator/toPromise';
import '../../../../js/quillEditor.js'

declare var companyEditor: any;

@Injectable()
export class CompanyService {
   
    
    /* Service */
    companies = [] as Company[];
    selectedCompany = {} as Company;
    show: boolean = false;
    allowAboutEditor: boolean = true;
    allowPrivacyEditor: boolean = true;
    allowTermsOfUseEditor: boolean = true;

    constructor(private companyRepository: CompanyRepository) { }

    init(): Promise<Company[]> {
        return this.getCompanies();
    }

    getAll(): Company[] {
        return this.companies;
    }

    getCurrent(): Company {
        return this.selectedCompany;
    }


    setCurrent(id: number): Promise<Company> {
        return this.companyRepository.get(id)
            .then((resp: Company) => {
                this.selectedCompany = resp;
                return this.selectedCompany;
            });
    }

    create(): Promise<Company> {
        return this.companyRepository.create()
            .then((resp: Company) => {
                this.selectedCompany = resp;
                this.companies.push(this.selectedCompany);
                return this.selectedCompany;
            });
    }

    save(): Promise<void> {
        return this.companyRepository.save(this.selectedCompany)
            .then(() => {
                for (let i = 0; i < this.companies.length; i++) {
                    if (this.selectedCompany.id === this.companies[i].id) {
                        this.companies[i] = this.selectedCompany;
                    }
                }
            });
    }

    remove(id: number): Promise<void> {
        return this.companyRepository.remove(id)
            .then(() => {
                this.companies = this.companies.filter((obj: Company) => (obj.id !== id));
                this.setCurrent(this.companies[0].id);
            });
    }

    private getCompanies(): Promise<Company[]> {
        return this.companyRepository
            .getAll(true, true, true)
            .then((companies: Company[]) => {
                this.companies = companies;
                //return this.companyRepository.get(this.companies[0].id);
                return this.companies.length <= 0 ? null : this.companyRepository.get(this.companies[0].id);//TODO: check null
            })
            .then((resp: Company) => {
                this.selectedCompany = resp;
                return this.companies;
            });
    }

    /* Text Editor */
    callAboutEditor(): Promise<void>  {
        if (!this.allowAboutEditor)
            return;
        this.allowAboutEditor = false;
        return companyEditor.aboutEditor();
    }

    callPrivacyEditor(): Promise<void> {
        if (!this.allowPrivacyEditor)
            return;
        this.allowPrivacyEditor = false;
        return companyEditor.privacyEditor();
    }

    callTermOfUseEditor(): Promise<void> {
        if (!this.allowTermsOfUseEditor)
            return;
        this.allowTermsOfUseEditor = false;
        return companyEditor.termOfUseEditor();
    }
}
