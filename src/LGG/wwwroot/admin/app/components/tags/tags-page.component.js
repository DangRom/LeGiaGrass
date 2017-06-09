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
var tag_service_1 = require("./tag.service");
var TagsPageComponent = (function () {
    function TagsPageComponent(tagService) {
        this.tagService = tagService;
        this.loading = false;
    }
    TagsPageComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.loading = true;
        this.tagService.init()
            .then(function () {
            _this.loading = false;
        });
    };
    TagsPageComponent.prototype.remove = function (id) {
        var _this = this;
        if (confirm("Are you sure you want to delete \"" + this.tagService.getCurrent().name + "\" from the tags list?")) {
            this.loading = true;
            this.tagService.remove(id)
                .then(function () {
                _this.loading = false;
            });
        }
    };
    TagsPageComponent.prototype.save = function () {
        var _this = this;
        if (this.tagService.getCurrent() == null)
            return;
        if (confirm("Are you sure you want to save \"" + this.tagService.getCurrent().name + "\" changes")) {
            this.loading = true;
            this.tagService.save()
                .then(function () {
                _this.loading = false;
            });
        }
    };
    return TagsPageComponent;
}());
TagsPageComponent = __decorate([
    core_1.Component({
        selector: 'pc-tags-page',
        templateUrl: './app/components/tags/templates/tags-page.component.html'
    }),
    __metadata("design:paramtypes", [tag_service_1.TagService])
], TagsPageComponent);
exports.TagsPageComponent = TagsPageComponent;
