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
var post_repository_1 = require("../../repositories/post.repository");
var post_tag_repository_1 = require("../../repositories/post-tag.repository");
require("rxjs/add/operator/toPromise");
var PostService = (function () {
    function PostService(postRepository, postTagRepository) {
        this.postRepository = postRepository;
        this.postTagRepository = postTagRepository;
        this.posts = [];
        this.selectedPost = {};
        this.countPerPage = 10;
        this.currentPageIndex = 1;
        // TODO: This is an issue.  The initial state of the pager will represent this, not what comes from the repo.
        this.totalItemsInCollection = 1000;
        this.show = false;
    }
    PostService.prototype.init = function () {
        var _this = this;
        return this.postRepository.getAll(this.countPerPage, this.currentPageIndex, false, false, true)
            .then(function (posts) {
            _this.posts = posts;
            //return this.postRepository.get(this.posts[0].url, true);
            return _this.posts.length <= 0 ? null : _this.postRepository.get(_this.posts[0].url, true); //TODO: check null
        })
            .then(function (resp) {
            _this.selectedPost = resp;
            return _this.postRepository.getTotalNumberOfPosts();
        })
            .then(function (resp) {
            _this.totalItemsInCollection = resp;
            return _this.posts;
        });
    };
    PostService.prototype.getAll = function () {
        return this.posts;
    };
    PostService.prototype.getCurrent = function () {
        return this.selectedPost;
    };
    PostService.prototype.getDescriptionLength = function () {
        return this.selectedPost.description ? this.selectedPost.description.length : 0;
    };
    PostService.prototype.setCurrent = function (idUrl) {
        var _this = this;
        return this.postRepository.get(idUrl, true)
            .then(function (resp) {
            _this.selectedPost = resp;
            return _this.selectedPost;
        });
    };
    PostService.prototype.create = function () {
        var _this = this;
        return this.postRepository.create()
            .then(function () {
            return _this.init();
        })
            .then(function (resp) {
            return resp;
        });
    };
    PostService.prototype.save = function () {
        var _this = this;
        return this.postRepository.save(this.selectedPost)
            .then(function () {
            for (var i = 0; i < _this.posts.length; i++) {
                if (_this.selectedPost.postId === _this.posts[i].postId) {
                    _this.posts[i] = _this.selectedPost;
                }
            }
        });
    };
    PostService.prototype.remove = function (idUrl) {
        var _this = this;
        return this.postRepository.remove(idUrl)
            .then(function () {
            _this.posts = _this.posts.filter(function (obj) { return (obj.url !== idUrl); });
            _this.setCurrent(_this.posts[0].url);
        });
    };
    PostService.prototype.resetPosts = function () {
        var _this = this;
        // TODO: Abstract out - shared with init
        return this.postRepository.getAll(this.countPerPage, this.currentPageIndex, false, false, true)
            .then(function (posts) {
            _this.posts = posts;
            return _this.postRepository.get(_this.posts[0].url, true);
        })
            .then(function (resp) {
            _this.selectedPost = resp;
            return _this.postRepository.getTotalNumberOfPosts();
        })
            .then(function (resp) {
            _this.totalItemsInCollection = resp;
            return _this.posts;
        });
    };
    PostService.prototype.replaceCategory = function (category) {
        this.getCurrent().category = category;
        return this.save();
    };
    PostService.prototype.addTag = function (tag) {
        return this.postTagRepository.add(tag.tagId, this.selectedPost.postId)
            .then(function () {
        });
    };
    PostService.prototype.removeTag = function (tag) {
        var _this = this;
        return this.postTagRepository.removeByCompound(tag.tagId, this.selectedPost.postId)
            .then(function () {
            for (var i = 0; i < _this.selectedPost.tags.length; i++) {
                if (tag.tagId === _this.selectedPost.tags[i].tagId) {
                    _this.selectedPost.tags.splice(i, 1);
                    return;
                }
            }
        });
    };
    PostService.prototype.isTagSet = function (tag) {
        if (!this.selectedPost.tags) {
            return false;
        }
        for (var i = 0; i < this.selectedPost.tags.length; i++) {
            if (tag.tagId === this.selectedPost.tags[i].tagId) {
                return true;
            }
        }
        return false;
    };
    return PostService;
}());
PostService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [post_repository_1.PostRepository, post_tag_repository_1.PostTagRepository])
], PostService);
exports.PostService = PostService;
