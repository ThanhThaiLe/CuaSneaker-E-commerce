import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Error500Component } from './error-500.component';
import { error500Routes } from './error-500.routing';
import { CommonModule } from '@angular/common';
import { commonModule } from '@fuse/components/commonComponent/common.module';

@NgModule({
    declarations: [Error500Component],
    imports: [
        RouterModule.forChild(error500Routes),
        CommonModule,
        commonModule,
    ],
})
export class Error500Module {}
