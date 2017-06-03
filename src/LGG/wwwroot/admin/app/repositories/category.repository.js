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
var CategoryRepository = (function () {
    function CategoryRepository(http) {
        this.http = http;
        this.url = '/api/categories';
    }
    CategoryRepository.prototype.get = function (id, includeExcerpt) {
        if (includeExcerpt === void 0) { includeExcerpt = false; }
        return this.http.get(this.url + '/' + id)
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || {};
        })
            .catch(this.handleError);
    };
    CategoryRepository.prototype.getAll = function () {
        return this.http.get(this.url)
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || [];
        })
            .catch(this.handleError);
    };
    CategoryRepository.prototype.create = function () {
        return this.http.post(this.url, {})
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || [];
        })
            .catch(this.handleError);
    };
    CategoryRepository.prototype.save = function (category) {
        return this.http.put(this.url + '\\' + category.categoryId, category)
            .toPromise()
            .catch(this.handleError);
    };
    CategoryRepository.prototype.remove = function (id) {
        return this.http.delete(this.url + '\\' + id)
            .toPromise()
            .catch(this.handleError);
    };
    CategoryRepository.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    return CategoryRepository;
}());
CategoryRepository = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], CategoryRepository);
exports.CategoryRepository = CategoryRepository;
