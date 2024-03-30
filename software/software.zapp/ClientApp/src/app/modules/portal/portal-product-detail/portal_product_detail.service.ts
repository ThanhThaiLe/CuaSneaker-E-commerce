import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take, map } from 'lodash';
import { BehaviorSubject, Observable, ReplaySubject, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { portal_san_pham_model } from '../portal.types';

@Injectable({
    providedIn: 'root',
})
export class PortalProductDetailService {
    private product: ReplaySubject<portal_san_pham_model> =
        new ReplaySubject<portal_san_pham_model>(1);
    constructor(private _httpClient: HttpClient) {}
    /**
     * Getter for notifications
     */
    get product$(): Observable<portal_san_pham_model> {
        return this.product.asObservable();
    }

    /**
     * get_detail_san_pham
     *
     * @param credentials
     */
    get_detail_san_pham(
        ma_san_pham: string
    ): Observable<portal_san_pham_model> {
        return this._httpClient
            .post('portal_san_pham.ctr/get_detail_san_pham', {
                ma_san_pham: ma_san_pham,
            })
            .pipe(
                switchMap((response: portal_san_pham_model) => {
                    return of(response);
                })
            );
    }
}
