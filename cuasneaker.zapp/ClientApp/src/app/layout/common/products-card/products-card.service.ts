import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { portal_san_pham_chi_tiet_card_model } from 'app/modules/portal/portal.types';

@Injectable({
    providedIn: 'root',
})
export class ShoppingCardsService {
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
    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------
    /**
     * Create a product
     *
     * @param product
     */
    create(product: portal_san_pham_chi_tiet_card_model) {
        this.product.next(product);
    }
}
