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
var PostRepository = (function () {
    function PostRepository(http) {
        this.http = http;
        this.url = '/api/posts';
    }
    PostRepository.prototype.get = function (idUrl, includeExcerpt) {
        if (includeExcerpt === void 0) { includeExcerpt = false; }
        return this.http.get(this.url + '/' + idUrl + '?includeExcerpt=' + includeExcerpt, {
            withCredentials: true
        })
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || {};
        })
            .catch(this.handleError);
    };
    PostRepository.prototype.getAll = function (count, page, includeExcerpt, includeArticle, includeUnpublished) {
        if (count === void 0) { count = null; }
        if (page === void 0) { page = null; }
        if (includeExcerpt === void 0) { includeExcerpt = true; }
        if (includeArticle === void 0) { includeArticle = true; }
        if (includeUnpublished === void 0) { includeUnpublished = true; }
        return this.http.get(this.url + '?countPerPage=' + count + '&currentPageIndex=' + page + '&ncludeExceprt=' + includeExcerpt + '&includeArticle=' + includeArticle + '&includeUnpublished=' + includeUnpublished)
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || [];
        })
            .catch(this.handleError);
    };
    PostRepository.prototype.create = function () {
        return this.http.post(this.url, {}, {
            withCredentials: true
        })
            .toPromise()
            .then(function (res) {
            var body = res.json();
            return body || [];
        })
            .catch(this.handleError);
    };
    PostRepository.prototype.save = function (post) {
        return this.http.put(this.url + '\\' + post.postId, post)
            .toPromise()
            .catch(this.handleError);
    };
    PostRepository.prototype.remove = function (idUrl) {
        return this.http.delete(this.url + '\\' + idUrl)
            .toPromise()
            .catch(this.handleError);
    };
    PostRepository.prototype.getTotalNumberOfPosts = function () {
        return this.http.get(this.url + '\\count\\total')
            .toPromise()
            .then(function (res) {
            return res.json();
        })
            .catch(this.handleError);
    };
    PostRepository.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    return PostRepository;
}());
PostRepository = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], PostRepository);
exports.PostRepository = PostRepository;
