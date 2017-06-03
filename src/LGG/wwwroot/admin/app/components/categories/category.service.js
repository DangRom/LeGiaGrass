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
var category_repository_1 = require("../../repositories/category.repository");
require("rxjs/add/operator/toPromise");
var CategoryService = (function () {
    function CategoryService(categoryRepository) {
        this.categoryRepository = categoryRepository;
        this.categories = [];
        this.selectedCategory = {};
    }
    CategoryService.prototype.init = function () {
        return this.getCategories();
    };
    CategoryService.prototype.getAll = function () {
        return this.categories;
    };
    CategoryService.prototype.getCurrent = function () {
        return this.selectedCategory;
    };
    CategoryService.prototype.setCurrent = function (id) {
        var _this = this;
        return this.categoryRepository.get(id, true)
            .then(function (resp) {
            _this.selectedCategory = resp;
            return _this.selectedCategory;
        });
    };
    CategoryService.prototype.create = function () {
        var _this = this;
        return this.categoryRepository.create()
            .then(function (resp) {
            _this.selectedCategory = resp;
            _this.categories.push(_this.selectedCategory);
            return _this.selectedCategory;
        });
    };
    CategoryService.prototype.save = function () {
        var _this = this;
        return this.categoryRepository.save(this.selectedCategory)
            .then(function () {
            for (var i = 0; i < _this.categories.length; i++) {
                if (_this.selectedCategory.categoryId === _this.categories[i].categoryId) {
                    _this.categories[i] = _this.selectedCategory;
                }
            }
        });
    };
    CategoryService.prototype.remove = function (id) {
        var _this = this;
        return this.categoryRepository.remove(id)
            .then(function () {
            _this.categories = _this.categories.filter(function (obj) { return (obj.categoryId !== id); });
            _this.setCurrent(_this.categories[0].categoryId);
        });
    };
    CategoryService.prototype.getCategories = function () {
        var _this = this;
        return this.categoryRepository.getAll()
            .then(function (categories) {
            _this.categories = categories;
            return _this.categoryRepository.get(_this.categories[0].categoryId, true);
        })
            .then(function (resp) {
            _this.selectedCategory = resp;
            return _this.categories;
        });
    };
    return CategoryService;
}());
CategoryService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [category_repository_1.CategoryRepository])
], CategoryService);
exports.CategoryService = CategoryService;
