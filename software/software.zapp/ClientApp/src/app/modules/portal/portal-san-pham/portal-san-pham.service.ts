import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { map, switchMap, take } from 'rxjs/operators';
import { portal_san_pham_model } from './portal_san_pham.types';
@Injectable({
    providedIn: 'root',
})
export class PortalSanPhamService {
    private _list_san_phams: ReplaySubject<portal_san_pham_model[]> =
        new ReplaySubject<portal_san_pham_model[]>();
    constructor(private _httpClient: HttpClient) {}
    /**
     * Getter for list_san_phams
     */
    get list_san_phams$(): Observable<portal_san_pham_model[]> {
        return this._list_san_phams.asObservable();
    }
    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------
    /**
     * Store list_san_phams on the service
     *
     * @param list_san_phams
     */
    store(
        list_san_phams: portal_san_pham_model[]
    ): Observable<portal_san_pham_model[]> {
        // Load the list_san_phams
        this._list_san_phams.next(list_san_phams);

        // Return the list_san_phams
        return this.list_san_phams$;
    }

    /**
     * Create a list_san_pham
     *
     * @param list_san_pham
     */
    create(
        list_san_pham: portal_san_pham_model
    ): Observable<portal_san_pham_model> {
        return this.list_san_phams$.pipe(
            take(1),
            switchMap((list_san_phams) =>
                this._httpClient
                    .post<portal_san_pham_model>('api/common/list_san_phams', {
                        list_san_pham,
                    })
                    .pipe(
                        map((new_list_san_pham) => {
                            // Update the list_san_phams with the new list_san_pham
                            this._list_san_phams.next([
                                ...list_san_phams,
                                new_list_san_pham,
                            ]);
                            // Return the new list_san_pham from observable
                            return new_list_san_pham;
                        })
                    )
            )
        );
    }

    /**
     * Update the list_san_pham
     *
     * @param id
     * @param list_san_pham
     */
    update(
        id: string,
        list_san_pham: portal_san_pham_model
    ): Observable<portal_san_pham_model> {
        return this.list_san_phams$.pipe(
            take(1),
            switchMap((list_san_phams) =>
                this._httpClient
                    .patch<portal_san_pham_model>('api/common/list_san_phams', {
                        id,
                        list_san_pham,
                    })
                    .pipe(
                        map((updated_list_san_pham: portal_san_pham_model) => {
                            // Find the index of the updated list_san_pham
                            const index = list_san_phams.findIndex(
                                (item) => item.id === id
                            );
                            // Update the list_san_pham
                            list_san_phams[index] = updated_list_san_pham;
                            // Update the list_san_phams
                            this._list_san_phams.next(list_san_phams);
                            // Return the updated list_san_pham
                            return updated_list_san_pham;
                        })
                    )
            )
        );
    }
    /**
     * Delete the list_san_pham
     *
     * @param id
     */
    delete(id: string): Observable<boolean> {
        return this.list_san_phams$.pipe(
            take(1),
            switchMap((list_san_phams) =>
                this._httpClient
                    .delete<boolean>('api/common/list_san_phams', {
                        params: { id },
                    })
                    .pipe(
                        map((isDeleted: boolean) => {
                            // Find the index of the deleted list_san_pham
                            const index = list_san_phams.findIndex(
                                (item) => item.id === id
                            );

                            // Delete the list_san_pham
                            list_san_phams.splice(index, 1);

                            // Update the list_san_phams
                            this._list_san_phams.next(list_san_phams);

                            // Return the deleted status
                            return isDeleted;
                        })
                    )
            )
        );
    }
}
