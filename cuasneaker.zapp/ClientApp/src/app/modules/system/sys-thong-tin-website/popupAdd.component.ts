import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import {
    MAT_DIALOG_DATA,
    MatDialog,
    MatDialogRef,
} from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { FuseNavigationService } from '@fuse/components/navigation';
import { TranslocoService } from '@ngneat/transloco';
import { BasePopUpAddTypeComponent } from 'app/Basecomponent/BasePopupAddType.component';
import { sys_thong_tin_website_model } from './sys-thong-tin-website.types';

@Component({
    selector: 'sys_thong_tin_website_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class sys_thong_tin_website_popupAddComponent extends BasePopUpAddTypeComponent<sys_thong_tin_website_model> {
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<sys_thong_tin_website_popupAddComponent>,
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
            'sys_thong_tin_website',
            dialogRef,
            dialogModal
        );
        this.record = data;
        this.actionEnum = data.actionEnum;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        if (this.actionEnum == 1) {
            this.baseInitData();
        }
    }
    public image_logo: any;
    public fileUploadProgressImage_logo: number = -1;
    ChoseFileImageimage_logo(image_logo: any) {
        this.image_logo = image_logo.target.files;
        this.submitFileimage_logo();
        image_logo.target.value = null;
    }
    DragAndDropProgressimage_logo(image_logo: any) {
        this.image_logo = image_logo;
        this.submitFileimage_logo();
    }
    submitFileimage_logo() {
        this.fileUploadProgressImage_logo = 0;
        var formData = new FormData();
        for (var i = 0; i < this.image_logo.length; i++) {
            if (this.image_logo[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.image_logo[i]);
        }
        formData.append('controller', this.controller.toString());
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressImage_logo = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image_logo = item.location.file_path;
                    this.image_logo = [];
                    this.fileUploadProgressImage_logo = -1;
                }
            });
    }

    public image_footer: any;
    public fileUploadProgressimage_footer: number = -1;
    ChoseFileImageimage_footer(image_footer: any) {
        this.image_footer = image_footer.target.files;
        this.submitFileimage_footer();
        image_footer.target.value = null;
    }
    DragAndDropProgressimage_footer(image_footer: any) {
        this.image_footer = image_footer;
        this.submitFileimage_footer();
    }
    submitFileimage_footer() {
        this.fileUploadProgressimage_footer = 0;
        var formData = new FormData();
        for (var i = 0; i < this.image_footer.length; i++) {
            if (this.image_footer[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.image_footer[i]);
        }
        formData.append('controller', this.controller.toString());
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressimage_footer = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image_footer = item.location.file_path;
                    this.image_footer = [];
                    this.fileUploadProgressimage_footer = -1;
                }
            });
    }

    public image_facebook: any;
    public fileUploadProgressimage_facebook: number = -1;
    ChoseFileImageimage_facebook(image_facebook: any) {
        this.image_facebook = image_facebook.target.files;
        this.submitFileimage_facebook();
        image_facebook.target.value = null;
    }
    DragAndDropProgressimage_facebook(image_facebook: any) {
        this.image_facebook = image_facebook;
        this.submitFileimage_facebook();
    }
    submitFileimage_facebook() {
        this.fileUploadProgressimage_facebook = 0;
        var formData = new FormData();
        for (var i = 0; i < this.image_facebook.length; i++) {
            if (this.image_facebook[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.image_facebook[i]);
        }
        formData.append('controller', this.controller.toString());
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressimage_facebook = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image_facebook = item.location.file_path;
                    this.image_facebook = [];
                    this.fileUploadProgressimage_facebook = -1;
                }
            });
    }

    public image_youtube: any;
    public fileUploadProgressimage_youtube: number = -1;
    ChoseFileImageimage_youtube(image_youtube: any) {
        this.image_youtube = image_youtube.target.files;
        this.submitFileimage_youtube();
        image_youtube.target.value = null;
    }
    DragAndDropProgressimage_youtube(image_youtube: any) {
        this.image_youtube = image_youtube;
        this.submitFileimage_youtube();
    }
    submitFileimage_youtube() {
        this.fileUploadProgressimage_youtube = 0;
        var formData = new FormData();
        for (var i = 0; i < this.image_youtube.length; i++) {
            if (this.image_youtube[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.image_youtube[i]);
        }
        formData.append('controller', this.controller.toString());
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressimage_youtube = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image_youtube = item.location.file_path;
                    this.image_youtube = [];
                    this.fileUploadProgressimage_youtube = -1;
                }
            });
    }

    public image_linkedin: any;
    public fileUploadProgressimage_linkedin: number = -1;
    ChoseFileImageimage_linkedin(image_linkedin: any) {
        this.image_linkedin = image_linkedin.target.files;
        this.submitFileimage_linkedin();
        image_linkedin.target.value = null;
    }
    DragAndDropProgressimage_linkedin(image_linkedin: any) {
        this.image_linkedin = image_linkedin;
        this.submitFileimage_linkedin();
    }
    submitFileimage_linkedin() {
        this.fileUploadProgressimage_linkedin = 0;
        var formData = new FormData();
        for (var i = 0; i < this.image_linkedin.length; i++) {
            if (this.image_linkedin[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.image_linkedin[i]);
        }
        formData.append('controller', this.controller.toString());
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressimage_linkedin = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image_linkedin = item.location.file_path;
                    this.image_linkedin = [];
                    this.fileUploadProgressimage_linkedin = -1;
                }
            });
    }

    public image_instagram: any;
    public fileUploadProgressimage_instagram: number = -1;
    ChoseFileImageimage_instagram(image_instagram: any) {
        this.image_instagram = image_instagram.target.files;
        this.submitFileimage_instagram();
        image_instagram.target.value = null;
    }
    DragAndDropProgressimage_instagram(image_instagram: any) {
        this.image_instagram = image_instagram;
        this.submitFileimage_instagram();
    }
    submitFileimage_instagram() {
        this.fileUploadProgressimage_instagram = 0;
        var formData = new FormData();
        for (var i = 0; i < this.image_instagram.length; i++) {
            if (this.image_instagram[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.image_instagram[i]);
        }
        formData.append('controller', this.controller.toString());
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressimage_instagram = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image_instagram = item.location.file_path;
                    this.image_instagram = [];
                    this.fileUploadProgressimage_instagram = -1;
                }
            });
    }
}
