﻿import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Company } from '../models/company';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class CompanyRepository {
    private url = '/api/companies';

    constructor(private http: Http) { }

    get(id: number): Promise<Company> {
        return this.http.get(this.url + '/' + id)
            .toPromise()
            .then((res: Response) => {
                const body: Company = res.json();
                return body || {} as Company;
            })
            .catch(this.handleError);
    }

    getAll(includeAbout: boolean = true,
        includePrivacy: boolean = true,
        includeTermsOfUse:boolean = true): Promise<Company[]> {
        return this.http.get(this.url + '?includeAbout=' + includeAbout + '&includePrivacy=' + includePrivacy + '&includeTermsOfUse=' + includeTermsOfUse)
            .toPromise()
            .then((res: Response) => {
                const body: Company[] = res.json();
                return body || [];
            })
            .catch(this.handleError);
    }

    create(): Promise<Company> {
        return this.http.post(this.url, {} as Company, {
            withCredentials: true
        })
            .toPromise()
            .then((res: Response) => {
                const body: Company = res.json();
                return body || {} as Company;
            })
            .catch(this.handleError);
    }

    save(company: Company): Promise<Response> {
        return this.http.put(this.url + '\\' + company.id, company)
            .toPromise()
            .catch(this.handleError);
    }

    remove(id: number): Promise<Response> {
        return this.http.delete(this.url + '\\' + id)
            .toPromise()
            .catch(this.handleError);
    }
   
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}