import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';
@Component({
    selector: 'app-sneaker-man',
    templateUrl: './sneaker-man.component.html',
    styleUrls: ['./sneaker-man.component.scss'],
})
export class SneakerManComponent implements OnInit {
    constructor() {}

    ngOnInit(): void {
        AOS.init({ duration: 1000 });
    }
}
