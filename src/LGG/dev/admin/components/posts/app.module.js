"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var app_component_1 = require("./app.component");
var posts_page_component_1 = require("./posts-page.component");
var post_repository_1 = require("../../repositories/post.repository");
var category_repository_1 = require("../../repositories/category.repository");
var tag_repository_1 = require("../../repositories/tag.repository");
var post_tag_repository_1 = require("../../repositories/post-tag.repository");
var post_service_1 = require("./post.service");
var tag_service_1 = require("../tags/tag.service");
var category_service_1 = require("../categories/category.service");
var truncate_pipe_1 = require("../../pipes/truncate.pipe");
var loader_component_1 = require("../shared/loader/loader.component");
var pager_component_1 = require("../shared/pager/pager.component");
var tinymce_1 = require("../shared/tinymce/tinymce");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule
        ],
        declarations: [
            app_component_1.AppComponent,
            posts_page_component_1.PostsPageComponent,
            truncate_pipe_1.TruncatePipe,
            loader_component_1.LoaderComponent,
            pager_component_1.PagerComponent,
            tinymce_1.TinyComponent
        ],
        providers: [
            post_repository_1.PostRepository,
            post_tag_repository_1.PostTagRepository,
            category_repository_1.CategoryRepository,
            tag_repository_1.TagRepository,
            post_service_1.PostService,
            category_service_1.CategoryService,
            tag_service_1.TagService
        ],
        bootstrap: [
            app_component_1.AppComponent
        ]
    })
], AppModule);
exports.AppModule = AppModule;
