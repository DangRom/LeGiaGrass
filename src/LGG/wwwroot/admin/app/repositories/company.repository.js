"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/add/operator/toPromise");
var CompanyRepository = (function () {
    function CompanyRepository(http) {
        this.http = http;
        this.url = '/api/companies';
    }
    CompanyRepository.prototype.get = function (id) {
        return this.http.get(this.url + '/' + id)
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || {};
        })
            .catch(this.handleError);
    };
    CompanyRepository.prototype.getAll = function (includeAbout, includePrivacy, includeTermsOfUse) {
        if (includeAbout === void 0) { includeAbout = true; }
        if (includePrivacy === void 0) { includePrivacy = true; }
        if (includeTermsOfUse === void 0) { includeTermsOfUse = true; }
        return this.http.get(this.url + '?includeAbout=' + includeAbout + '&includePrivacy=' + includePrivacy + '&includeTermsOfUse=' + includeTermsOfUse)
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || [];
        })
            .catch(this.handleError);
    };
    CompanyRepository.prototype.create = function () {
        return this.http.post(this.url, {}, {
            withCredentials: true
        })
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || {};
        })
            .catch(this.handleError);
    };
    CompanyRepository.prototype.save = function (company) {
        return this.http.put(this.url + '\\' + company.id, company)
            .toPromise()
            .catch(this.handleError);
    };
    CompanyRepository.prototype.remove = function (id) {
        return this.http.delete(this.url + '\\' + id)
            .toPromise()
            .catch(this.handleError);
    };
    CompanyRepository.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    return CompanyRepository;
}());
CompanyRepository = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], CompanyRepository);
exports.CompanyRepository = CompanyRepository;
