import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';
@Component({
    selector: 'app-sneaker-woman',
    templateUrl: './sneaker-woman.component.html',
    styleUrls: ['./sneaker-woman.component.scss'],
})
export class SneakerWomanComponent implements OnInit {
    constructor() {}

    ngOnInit(): void {
        AOS.init({ duration: 1000 });
    }
}
