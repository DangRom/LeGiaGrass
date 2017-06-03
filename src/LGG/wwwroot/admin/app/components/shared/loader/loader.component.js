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
var LoaderComponent = (function () {
    function LoaderComponent() {
        this.loading = false;
    }
    return LoaderComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], LoaderComponent.prototype, "loading", void 0);
LoaderComponent = __decorate([
    core_1.Component({
        selector: 'pc-loader',
        template: "\n  <section class=\"pc-loader\" *ngIf=\"loading\">\n    <div class=\"pc-loader-overlay\"></div>\n    <div class=\"pc-loader-wrapper\">\n      <i class=\"fa fa-spinner fa-pulse fa-fw\"></i>\n    </div>\n  </section>\n  "
    })
], LoaderComponent);
exports.LoaderComponent = LoaderComponent;
