import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take, map } from 'lodash';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { portal_san_pham_chi_tiet_card_model } from '../portal.types';

@Injectable({
    providedIn: 'root',
})
export class PortalShoppingCardServiceService {
    /**
     * Variables
     */
    /**
     * Variables
     */
    private product: BehaviorSubject<portal_san_pham_chi_tiet_card_model> =
        new BehaviorSubject<portal_san_pham_chi_tiet_card_model>(null);
    /**
     * Constructor
     */
    constructor(private _httpClient: HttpClient) {}
    /**
     * Getter for notifications
     */
    get product$(): Observable<portal_san_pham_chi_tiet_card_model> {
        return this.product.asObservable();
    }

    /**
     * Delete the notification
     *
     * @param id
     */
    delete(product: portal_san_pham_chi_tiet_card_model) {
        this.product.next(product);
    }
    /**
     * Create a product
     *
     * @param product
     */
    create(product: portal_san_pham_chi_tiet_card_model) {
        this.product.next(product);
    }
}
