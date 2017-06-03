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
var post_service_1 = require("./post.service");
var category_service_1 = require("../categories/category.service");
var tag_service_1 = require("../tags/tag.service");
var PostsPageComponent = (function () {
    function PostsPageComponent(postService, categoryService, tagService) {
        this.postService = postService;
        this.categoryService = categoryService;
        this.tagService = tagService;
        this.loading = false;
    }
    PostsPageComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.loading = true;
        this.tagService.init()
            .then(function () {
            return _this.categoryService.init();
        })
            .then(function () {
            return _this.postService.init();
        })
            .then(function () {
            _this.loading = false;
        });
    };
    /**
     * Subscribe to pc-page event
     */
    PostsPageComponent.prototype.onPageClicked = function (selectedPage) {
        var _this = this;
        this.loading = true;
        this.postService.currentPageIndex = selectedPage;
        this.postService.resetPosts()
            .then(function () {
            _this.loading = false;
        });
    };
    PostsPageComponent.prototype.deleteRecord = function (idUrl) {
        var _this = this;
        if (confirm("Are you sure you want to delete \"" + this.postService.getCurrent().title + "\" from the posts list?")) {
            this.loading = true;
            this.postService.remove(idUrl)
                .then(function () {
                _this.loading = false;
            });
        }
    };
    PostsPageComponent.prototype.save = function (pos) {
        var _this = this;
        if (confirm("Are you sure you want to save \"" + this.postService.getCurrent().title + "\" changes")) {
            this.loading = true;
            this.postService.save()
                .then(function () {
                _this.loading = false;
            });
        }
    };
    PostsPageComponent.prototype.onCategoryClick = function (category) {
        var _this = this;
        this.loading = true;
        this.postService.replaceCategory(category)
            .then(function () {
            _this.loading = false;
        });
    };
    PostsPageComponent.prototype.onTagClick = function (tag) {
        var _this = this;
        this.loading = true;
        if (!this.postService.isTagSet(tag)) {
            this.postService.addTag(tag)
                .then(function () {
                _this.loading = false;
            });
            return;
        }
        this.postService.removeTag(tag)
            .then(function () {
            _this.loading = false;
        });
    };
    return PostsPageComponent;
}());
PostsPageComponent = __decorate([
    core_1.Component({
        selector: 'pc-posts-page',
        templateUrl: './app/components/posts/templates/posts-page.component.html'
    }),
    __metadata("design:paramtypes", [post_service_1.PostService,
        category_service_1.CategoryService,
        tag_service_1.TagService])
], PostsPageComponent);
exports.PostsPageComponent = PostsPageComponent;
