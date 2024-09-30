import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import {
    MAT_DIALOG_DATA,
    MatDialog,
    MatDialogRef,
} from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { FuseNavigationService } from '@fuse/components/navigation';
import { TranslocoService } from '@ngneat/transloco';
import { BasePopUpAddComponent } from 'app/Basecomponent/BasePopupAdd.component';

@Component({
    selector: 'sys_group_user_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class sys_group_user_popupAddComponent extends BasePopUpAddComponent {
    public additem: any;
    public additemRole: any;
    public item_chose: any;
    public searchUser: any = '';
    public searchRole: any = '';
    public listRoleFilter: any;
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<sys_group_user_popupAddComponent>,
        public dialogModal: MatDialog,
        public _fuseNavigationService: FuseNavigationService,
        @Inject(MAT_DIALOG_DATA) data: any,
        @Inject('BASE_URL') public _baseUrl: string
    ) {
        super(
            _translocoService,
            _fuseNavigationService,
            route,
            _baseUrl,
            http,
            'sys_group_user',
            dialogRef,
            dialogModal
        );

        this.record = data;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        this.actionEnum = this.record.actionEnum;

        this.resetAddItem();
        this.resetAddItemRole();
        this.http
            .post('sys_group_user.ctr/getListItem', {
                id: this.record.db.id,
            })
            .subscribe((resp) => {
                this.record.list_item = resp;
            });
        this.http
            .post('sys_group_user.ctr/getListRole', {
                id: this.record.db.id,
            })
            .subscribe((resp) => {
                this.record.list_role = resp;
                this.http
                    .post('sys_group_user.ctr/getListRoleFull', {})
                    .subscribe((resp) => {
                        this.listRoleFilter = resp;
                        this.resetListRole();
                    });
            });
        if (this.actionEnum == 2) {
            this.basedialogRef.keydownEvents().subscribe((event: any) => {
                if (event.key == 'Escape') {
                    this.basedialogRef.close();
                }
            });
        }
    }
    resetAddItem() {
        this.additem = {
            db: {
                user_id: null,
                note: '',
            },
            user_name: '',
        };
    }
    resetAddItemRole() {
        this.additemRole = {
            db: {
                id_controller_role: '',
                controller_name: '',
                role_name: '',
            },
        };
    }
    beforesave() {
        this.record.list_role = [];
        if (this.listRoleFilter != undefined) {
            for (let index = 0; index < this.listRoleFilter.length; index++) {
                const element = this.listRoleFilter[index];
                if (element.completed == true) {
                    this.record.list_role.push({
                        db: {
                            id_controller_role: element.role.id,
                            controller_name: element.controller_name,
                            role_name: element.role.name,
                        },
                    });
                } else {
                }
            }
        }
    }
    bind_data_item_chose() {
        this.additem.db.user_id = this.item_chose.id;
        this.additem.user_name = this.item_chose.name;
    }
    addDetail() {
        var valid = true;
        var error = '';
        if (
            this.record.list_item.filter(
                (resp: any) => resp.db.user_id == this.additem.db.user_id
            ).length > 0
        ) {
            error +=
                this._translocoService.translate('common.existed') + '</br>';
            valid = false;
        }
        if (
            this.additem.db.user_id == null ||
            this.additem.db.user_id == undefined
        ) {
            error +=
                this._translocoService.translate('common.must_chose_item') +
                '</br>';
            valid = false;
        }
        if (!valid) {
            //show message
            this.showLoading('', '', true);
            return;
        }
        this.record.list_item.push(this.additem);
        this.record.list_item.sort(function (a: any, b: any) {
            return a.db.step_num - b.db.step_num;
        });
        this.resetAddItem();
    }
    resetListRole() {
        for (let index = 0; index < this.listRoleFilter.length; index++) {
            const element = this.listRoleFilter[index];
            element.name =
                this._translocoService.translate(element.controller_name) +
                ' ' +
                this._translocoService.translate(element.role.name);
            if (
                this.record.list_role.filter(
                    (resp: any) =>
                        resp.db.id_controller_role ==
                        this.listRoleFilter[index].role.id
                ).length > 0
            ) {
                this.listRoleFilter[index].completed = true;
            } else {
                this.listRoleFilter[index].completed = false;
            }
        }
        this.updateAllCompleteRole();
    }
    deleteDetail(pos: any) {
        this.record.list_item.splice(pos, 1);
        this.resetListRole();
    }
    allComplete: boolean = false;

    updateAllComplete() {
        this.allComplete =
            this.record.list_item != null &&
            this.record.list_item.every((t: any) => t.isCheck);
    }

    someComplete(): boolean {
        if (this.record.list_item == null) {
            return false;
        }
        return (
            this.record.list_item.filter((t: any) => t.isCheck).length > 0 &&
            !this.allComplete
        );
    }

    setAll(completed: boolean) {
        this.allComplete = completed;
        if (this.record.list_item == null) {
            return;
        }
        this.record.list_item.forEach((t: any) => (t.isCheck = completed));
    }

    //role
    allCompleteRole: boolean = false;

    updateAllCompleteRole() {
        this.allCompleteRole =
            this.listRoleFilter != null &&
            this.listRoleFilter.every((t: any) => t.completed);
    }

    someCompleteRole(): boolean {
        if (this.listRoleFilter == null) {
            return false;
        }
        return (
            this.listRoleFilter.filter((t: any) => t.completed).length > 0 &&
            !this.allCompleteRole
        );
        // return this.listRoleFilter.filter((t: any) => t.completed).length > 0 && !this.allCompleteRole;
    }
    setAllRole(completed: boolean) {
        this.allCompleteRole = completed;
        if (this.listRoleFilter == null) {
            return;
        }
        this.listRoleFilter.forEach((t: any) => {
            t.completed = completed;
        });
        // this.listRoleFilter.forEach((t: any) => (t.completed = completed));
    }
    // getRoleUser() {
    //     this.http.post('sys_home.ctr/getModule', {}).subscribe((resp) => {});
    // }
}
