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
var category_service_1 = require("./category.service");
var CategoriesPageComponent = (function () {
    function CategoriesPageComponent(categoryService) {
        this.categoryService = categoryService;
        this.loading = false;
    }
    CategoriesPageComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.loading = true;
        this.categoryService.init()
            .then(function () {
            _this.loading = false;
        });
    };
    CategoriesPageComponent.prototype.deleteRecord = function (id) {
        var _this = this;
        if (confirm("Are you sure you want to delete \"" + this.categoryService.getCurrent().name + "\" from the categories list?")) {
            this.loading = true;
            this.categoryService.remove(id)
                .then(function () {
                _this.loading = false;
            });
        }
    };
    CategoriesPageComponent.prototype.save = function () {
        var _this = this;
        if (confirm("Are you sure you want to save \"" + this.categoryService.getCurrent().name + "\" changes")) {
            this.loading = true;
            this.categoryService.save()
                .then(function () {
                _this.loading = false;
            });
        }
    };
    return CategoriesPageComponent;
}());
CategoriesPageComponent = __decorate([
    core_1.Component({
        selector: 'pc-categories-page',
        templateUrl: './app/components/categories/templates/categories-page.component.html'
    }),
    __metadata("design:paramtypes", [category_service_1.CategoryService])
], CategoriesPageComponent);
exports.CategoriesPageComponent = CategoriesPageComponent;
