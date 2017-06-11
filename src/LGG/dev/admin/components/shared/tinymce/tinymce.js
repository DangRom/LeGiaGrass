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
require("tinymce");
require("tinymce/themes/modern");
require("tinymce/plugins/link/plugin.js");
require("tinymce/plugins/table/plugin.js");
require("tinymce/plugins/paste/plugin.js");
var TinyComponent = (function () {
    function TinyComponent() {
        this.onEditorChange = new core_1.EventEmitter();
    }
    TinyComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        tinymce.init({
            selector: "#" + this.elementId,
            plugins: ['link', 'paste', 'table'],
            skin_url: "/assets/skins/lightgray",
            menubar: "edit insert view format table tools",
            setup: function (editor) {
                _this.editor = editor;
                editor.on("Change", function () {
                    var content = editor.getContent();
                    _this.onEditorChange.emit(content);
                });
            }
        });
    };
    TinyComponent.prototype.ngOnDestroy = function () {
        tinymce.remove(this.editor);
    };
    return TinyComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], TinyComponent.prototype, "elementId", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], TinyComponent.prototype, "content", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], TinyComponent.prototype, "onEditorChange", void 0);
TinyComponent = __decorate([
    core_1.Component({
        selector: "tiny-editor",
        template: "<textarea id=\"{{elementId}}\">{{content}}</textarea>"
    })
], TinyComponent);
exports.TinyComponent = TinyComponent;
