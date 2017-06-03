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
var tag_repository_1 = require("../../repositories/tag.repository");
require("rxjs/add/operator/toPromise");
var TagService = (function () {
    function TagService(tagRepository) {
        this.tagRepository = tagRepository;
        this.tags = [];
        this.selectedTag = {};
    }
    TagService.prototype.init = function () {
        return this.getTags();
    };
    TagService.prototype.getAll = function () {
        return this.tags;
    };
    TagService.prototype.getCurrent = function () {
        return this.selectedTag;
    };
    TagService.prototype.setCurrent = function (id) {
        var _this = this;
        return this.tagRepository.get(id, true)
            .then(function (resp) {
            _this.selectedTag = resp;
            return _this.selectedTag;
        });
    };
    TagService.prototype.create = function () {
        var _this = this;
        return this.tagRepository.create()
            .then(function (resp) {
            _this.selectedTag = resp;
            _this.tags.push(_this.selectedTag);
            return _this.selectedTag;
        });
    };
    TagService.prototype.save = function () {
        var _this = this;
        return this.tagRepository.save(this.selectedTag)
            .then(function () {
            for (var i = 0; i < _this.tags.length; i++) {
                if (_this.selectedTag.tagId === _this.tags[i].tagId) {
                    _this.tags[i] = _this.selectedTag;
                }
            }
        });
    };
    TagService.prototype.remove = function (id) {
        var _this = this;
        return this.tagRepository.remove(id)
            .then(function () {
            _this.tags = _this.tags.filter(function (obj) { return (obj.tagId !== id); });
            _this.setCurrent(_this.tags[0].tagId);
        });
    };
    TagService.prototype.getTags = function () {
        var _this = this;
        return this.tagRepository
            .getAll()
            .then(function (tags) {
            _this.tags = tags;
            return _this.tagRepository.get(_this.tags[0].tagId, true);
        })
            .then(function (resp) {
            _this.selectedTag = resp;
            return _this.tags;
        });
    };
    return TagService;
}());
TagService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [tag_repository_1.TagRepository])
], TagService);
exports.TagService = TagService;
