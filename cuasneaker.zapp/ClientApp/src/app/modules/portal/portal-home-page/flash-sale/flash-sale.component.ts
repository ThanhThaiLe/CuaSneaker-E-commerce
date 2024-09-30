import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';
@Component({
    selector: 'app-flash-sale',
    templateUrl: './flash-sale.component.html',
    styleUrls: ['./flash-sale.component.scss'],
})
export class FlashSaleComponent implements OnInit {
    constructor() {}

    ngOnInit(): void {
        AOS.init({ duration: 1000 });
    }
}
