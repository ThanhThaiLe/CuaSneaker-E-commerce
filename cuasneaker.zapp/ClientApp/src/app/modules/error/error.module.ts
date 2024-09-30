import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { Error404Component } from './error-404/error-404.component';
import { commonModule } from '@fuse/components/commonComponent/common.module';
import { CommonModule } from '@angular/common';
import { Error500Component } from './error-500/error-500.component';
const portalRoutes: Route[] = [
    {
        path: '',
        component: Error404Component,
    },
    {
        path: '',
        component: Error500Component,
    },
];

@NgModule({
    declarations: [Error404Component, Error500Component],
    imports: [RouterModule.forChild(portalRoutes), CommonModule, commonModule],
})
export class Error404Module {}
