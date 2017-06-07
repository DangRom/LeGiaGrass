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
var company_repository_1 = require("../../repositories/company.repository");
require("rxjs/add/operator/toPromise");
var CompanyService = (function () {
    function CompanyService(companyRepository) {
        this.companyRepository = companyRepository;
        this.companies = [];
        this.selectedCompany = {};
    }
    CompanyService.prototype.init = function () {
        return this.getCompanies();
    };
    CompanyService.prototype.getAll = function () {
        return this.companies;
    };
    CompanyService.prototype.getCurrent = function () {
        return this.selectedCompany;
    };
    CompanyService.prototype.setCurrent = function (id) {
        var _this = this;
        return this.companyRepository.get(id)
            .then(function (resp) {
            _this.selectedCompany = resp;
            return _this.selectedCompany;
        });
    };
    CompanyService.prototype.create = function () {
        var _this = this;
        return this.companyRepository.create()
            .then(function (resp) {
            _this.selectedCompany = resp;
            _this.companies.push(_this.selectedCompany);
            return _this.selectedCompany;
        });
    };
    CompanyService.prototype.save = function () {
        var _this = this;
        return this.companyRepository.save(this.selectedCompany)
            .then(function () {
            for (var i = 0; i < _this.companies.length; i++) {
                if (_this.selectedCompany.id === _this.companies[i].id) {
                    _this.companies[i] = _this.selectedCompany;
                }
            }
        });
    };
    CompanyService.prototype.remove = function (id) {
        var _this = this;
        return this.companyRepository.remove(id)
            .then(function () {
            _this.companies = _this.companies.filter(function (obj) { return (obj.id !== id); });
            _this.setCurrent(_this.companies[0].id);
        });
    };
    CompanyService.prototype.getCompanies = function () {
        var _this = this;
        return this.companyRepository
            .getAll(true, true, true)
            .then(function (companies) {
            _this.companies = companies;
            return _this.companyRepository.get(_this.companies[0].id);
        })
            .then(function (resp) {
            _this.selectedCompany = resp;
            return _this.companies;
        });
    };
    return CompanyService;
}());
CompanyService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [company_repository_1.CompanyRepository])
], CompanyService);
exports.CompanyService = CompanyService;
