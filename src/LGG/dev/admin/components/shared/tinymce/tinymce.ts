import {
    Component,
    OnDestroy,
    OnChanges,
    AfterViewInit,
    EventEmitter,
    Input,
    Output
} from "@angular/core";

import 'tinymce'
import 'tinymce/themes/modern'
import 'tinymce/plugins/link/plugin.js'
import 'tinymce/plugins/table/plugin.js'
import 'tinymce/plugins/paste/plugin.js'

declare var tinymce: any;

@Component({
    selector: "tiny-editor",
    template: `<textarea id="{{elementId}}">{{content}}</textarea>`
})
export class TinyComponent implements AfterViewInit, OnDestroy {
    @Input() elementId: string;
    @Input() content: string;
    @Output() onEditorChange = new EventEmitter<any>();

    editor;

    ngAfterViewInit() {
        tinymce.init({
            selector: `#${this.elementId}`,
            plugins: ['link', 'paste', 'table'],
            skin_url: "/assets/skins/lightgray",
            menubar: "edit insert view format table tools",
            setup: editor => {
                this.editor = editor;
                editor.on("Change", () => {
                    const content = editor.getContent();
                    this.onEditorChange.emit(content);
                });
            }
        });
    }

    ngOnDestroy() {
        tinymce.remove(this.editor);
    }
}