import {
    Component,
    OnInit,
    Input,
    EventEmitter,
    Output,
    ChangeDetectorRef,
    ViewChild,
} from '@angular/core';
import { MatSelect } from '@angular/material/select';
import { TranslocoService } from '@ngneat/transloco';
@Component({
    selector: 'cm_select',
    templateUrl: './cm_select.component.html',
    styleUrls: ['./cm_select.component.scss'],
})
export class cm_selectComponent implements OnInit {
    @Input() errorModel: any;
    @Input() keyError: string;
    @Input() label: string;
    @Input() type: string;
    @Input() paramCallBack: string;
    @Input() model: any;
    @Input() model_check: any;
    @Input() disabled: any;
    @Input() showSearch: any = true;
    @Input() labelAddString: string;
    @Input() placeholder: string;
    @Input() actionEnum: any = 1;
    @Input() listData: any;
    @Input() callbackChange: Function;
    @Input() callbackChangeWithParam: Function;
    @Input() callbackChangeSecond: Function;
    @Input() callbackChangeSecondPos: Function;
    @Input() pos: any = 0;
    @Output() modelChange: EventEmitter<any> = new EventEmitter<any>();
    @Input() objectChose: any;
    @Output() objectChoseChange: EventEmitter<any> = new EventEmitter<any>();
    public search: string = '';
    public selected: any = [];
    public disable_old: any = [];
    public old_value: any = '';
    public old_value_multi: any = [];
    public list_object: any = [];
    @ViewChild('mySel') skillSel: MatSelect;
    constructor(
        private _translocoService: TranslocoService,
        private _changeDetectorRef: ChangeDetectorRef
    ) {
        if (this.type == '' || this.type == null) this.type = 'single';
    }

    ngOnInit() {
        if (
            this.placeholder == '' ||
            this.placeholder == null ||
            this.placeholder == undefined
        )
            this.placeholder =
                this._translocoService.translate('common.choose');
        if (this.actionEnum == 3) this.placeholder = '';
        this.old_value = this.model;
    }
    isDisable(obj) {
        if (this.actionEnum == 1) {
            if (this.disable_old.length == 0 && this.disabled.length >= 0) {
                this.disable_old = this.disabled;
            }
            var index = this.disable_old.indexOf(obj);
            if (index != -1) {
                return false;
            } else {
                return true;
            }
        }
    }
    changeSearch() {
        this._changeDetectorRef.detectChanges();
    }
    isChange = false;

    removeAccents(str) {
        var AccentsMap = [
            'aàảãáạăằẳẵắặâầẩẫấậ',
            'AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ',
            'dđ',
            'DĐ',
            'eèẻẽéẹêềểễếệ',
            'EÈẺẼÉẸÊỀỂỄẾỆ',
            'iìỉĩíị',
            'IÌỈĨÍỊ',
            'oòỏõóọôồổỗốộơờởỡớợ',
            'OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ',
            'uùủũúụưừửữứự',
            'UÙỦŨÚỤƯỪỬỮỨỰ',
            'yỳỷỹýỵ',
            'YỲỶỸÝỴ',
        ];
        for (var i = 0; i < AccentsMap.length; i++) {
            var re = new RegExp('[' + AccentsMap[i].substr(1) + ']', 'g');
            var char = AccentsMap[i][0];
            str = str.replace(re, char);
        }

        return str;
    }
    searchFunction(data): boolean {
        if (
            this.removeAccents(data.toLowerCase()).indexOf(
                this.removeAccents(this.search.toLowerCase())
            ) != -1
        )
            return false;
        return true;
    }
    setChose(data): void {
        if (this.isChange == true) {
            return;
        }
        this.isChange = true;
        if (this.type == 'single') {
            this.objectChose = this.listData.filter((d) => d.id == data)[0];
            this.isChange = false;
            this.objectChoseChange.emit(this.objectChose);
        } else {
            if (this.old_value.includes('-1')) {
                // this.skillSel.options.forEach((item: MatOption) =>
                //     item.value == '-1' ? item.deselect() : null
                // );
                this.model = this.model.filter((d) => d != '-1');
            } else if (data.includes('-1')) {
                this.model = ['-1'];
                // this.skillSel.options.forEach((item: MatOption) =>
                //     item.value != '-1' ? item.deselect() : item.select()
                // );
            }
            this.old_value = this.model;
            this.modelChange.emit(this.model);
            this.modelChange.emit(this.old_value);
            this._changeDetectorRef.detectChanges();
            this.isChange = false;
        }
        // this.objectChose = this.listData.filter((d) => d.id == data)[0];
        // this.objectChoseChange.emit(this.objectChose);
        if (this.callbackChange != undefined && this.callbackChange != null)
            this.callbackChange();
        if (
            this.callbackChangeSecond != undefined &&
            this.callbackChangeSecond != null
        ) {
            this.callbackChangeSecond();
        }
        if (
            this.callbackChangeSecondPos != undefined &&
            this.callbackChangeSecondPos != null
        ) {
            this.callbackChangeSecondPos(this.pos);
        }
        if (
            this.callbackChangeWithParam != undefined &&
            this.callbackChangeWithParam != null
        )
            if (this.paramCallBack != undefined && this.paramCallBack != null) {
                this.callbackChangeWithParam(this.paramCallBack, this.model);
            } else {
                this.callbackChangeWithParam(this.label, this.model);
            }
    }
}
