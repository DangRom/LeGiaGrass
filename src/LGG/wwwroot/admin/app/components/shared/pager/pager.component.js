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
var PagerComponent = (function () {
    function PagerComponent() {
        this.currentPageIndex = 1;
        this.countPerPage = 1;
        this.totalItemsInCollection = 1;
        this.onPageClicked = new core_1.EventEmitter();
        this.pager = {};
    }
    PagerComponent.prototype.ngOnInit = function () {
        this.setPager(this.currentPageIndex, this.totalItemsInCollection);
    };
    /**
     * Omit an event when a page is clicked
     */
    PagerComponent.prototype.onClick = function (selectedPage) {
        this.onPageClicked.emit(selectedPage);
        this.setPager(selectedPage, this.totalItemsInCollection);
    };
    PagerComponent.prototype.getPager = function () {
        return this.pager;
    };
    PagerComponent.prototype.setPager = function (page, totalItems) {
        if (page < 1 || page > this.pager.totalPages) {
            return;
        }
        this.pager = this.buildPagerObject(totalItems, page);
    };
    PagerComponent.prototype.buildPagerObject = function (totalItems, currentPage) {
        // default to first page
        currentPage = currentPage || 1;
        // calculate total pages
        var totalPages = Math.ceil(totalItems / this.countPerPage);
        var startPage;
        var endPage;
        if (totalPages <= 4) {
            // less than 4 total pages so show all
            startPage = 1;
            endPage = totalPages;
        }
        else {
            // more than 4 total pages so calculate start and end pages
            if (currentPage <= 3) {
                startPage = 1;
                endPage = 4;
            }
            else if (currentPage + 1 >= totalPages) {
                startPage = totalPages - 3;
                endPage = totalPages;
            }
            else {
                startPage = currentPage - 2;
                endPage = currentPage + 1;
            }
        }
        // calculate start and end item indexes
        var startIndex = (currentPage - 1) * this.countPerPage;
        var endIndex = Math.min(startIndex + this.countPerPage - 1, totalItems - 1);
        // create an array of pages *ngFor
        var pages = this.range(startPage, endPage + 1);
        return {
            totalItems: totalItems,
            currentPage: currentPage,
            pageSize: this.countPerPage,
            totalPages: totalPages,
            startPage: startPage,
            endPage: endPage,
            startIndex: startIndex,
            endIndex: endIndex,
            pages: pages
        };
    };
    /**
     * Generate an integer Array containing an arithmetic progression.
     * Inspired by _.range()
     */
    PagerComponent.prototype.range = function (start, stop, step) {
        if (stop == null) {
            stop = start || 0;
            start = 0;
        }
        if (!step) {
            step = stop < start ? -1 : 1;
        }
        var length = Math.max(Math.ceil((stop - start) / step), 0);
        var range = Array(length);
        for (var i = 0; i < length; i++, start += step) {
            range[i] = start;
        }
        return range;
    };
    return PagerComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], PagerComponent.prototype, "currentPageIndex", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], PagerComponent.prototype, "countPerPage", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], PagerComponent.prototype, "totalItemsInCollection", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], PagerComponent.prototype, "onPageClicked", void 0);
PagerComponent = __decorate([
    core_1.Component({
        selector: 'pc-pager',
        template: "\n  <section class=\"pc-pager\">\n    <ul class=\"pagination\" role=\"navigation\" aria-label=\"Pagination\">\n      <li class=\"pagination-previous\"\n          [ngClass]=\"{disabled : currentPageIndex === 1}\"\n          (click)=\"onClick(currentPageIndex - 1)\">\n        <a href=\"#\" *ngIf=\"currentPageIndex !== 1\" aria-label=\"Previous page page\"></a>\n      </li>\n      <li *ngFor=\"let page of getPager().pages\"\n          [ngClass]=\"{current: currentPageIndex === page}\">\n        <a (click)=\"onClick(page)\">{{page}}</a>\n      </li>\n      <li class=\"pagination-next\"\n          [ngClass]=\"{disabled : currentPageIndex === getPager().totalPages}\"\n          (click)=\"onClick(currentPageIndex + 1)\">\n        <a href=\"#\" *ngIf=\"currentPageIndex !== getPager().totalPages\" aria-label=\"Next page\"></a>\n      </li>\n    </ul>\n  </section>\n  "
    })
], PagerComponent);
exports.PagerComponent = PagerComponent;
