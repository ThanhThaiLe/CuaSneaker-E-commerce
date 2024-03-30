import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { FuseNavigationService } from '@fuse/components/navigation';
import { TranslocoService } from '@ngneat/transloco';
import { Subject } from 'rxjs';
import { portal_san_pham_chi_tiet_card_model } from '../portal.types';
import { Router } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { PortalShoppingCardServiceService } from './portal-shopping-card.service.service';
import * as AOS from 'aos';
import { ProductsCardPageComponent } from 'app/layout/common/products-card/products-card.component';
import { ShoppingCardsService } from 'app/layout/common/products-card/products-card.service';
import { SeoService } from '@fuse/services/seo.service';
@Component({
    selector: 'portal-shopping-card',
    templateUrl: './portal-shopping-card.component.html',
    styleUrls: ['./portal-shopping-card.component.scss'],
})
export class PortalShoppingCardComponent implements OnInit {
    public list_product_card: portal_san_pham_chi_tiet_card_model[] = [];
    public price_sum: number = 0;
    public loading: boolean = false;
    public pageLoading: Boolean = false;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    constructor(
        public seoService: SeoService,
        private _changeDetectorRef: ChangeDetectorRef,
        public dialog: MatDialog,
        private _portalShoppingCartService: PortalShoppingCardServiceService,
        public http: HttpClient,
        private _shoppingCardsService: ShoppingCardsService,
        private _router: Router,
        public _fuseNavigationService: FuseNavigationService,
        public _translocoService: TranslocoService
    ) {
        this._changeDetectorRef.markForCheck();
    }
    /**
     * @param index
     * is index in list product
     * @param type
     * type = 1 => plus and type = 2 => minus
     */
    plus_or_minus_product(index: number, type: number): void {
        let product = this.list_product_card[index];
        this.add_san_pham_to_card(product, type);
        this.list_product_card = this.list_product_card.filter(
            (q) =>
                q.id != product.id &&
                q.id_size != product.id_size &&
                q.id_color != product.id_color
        );
        if (type == 1) {
            product.so_luong += 1;
        }
        if (type == 2) {
            product.so_luong -= 1;
        }
        if (product.so_luong != 0) {
            this.list_product_card.push(product);
        }

        this.setLocalStorage();
    }
    go_to_payment() {
        var url = '/portal-payment';
        this._router.navigateByUrl(url);
    }
    changeCurrency(money): string {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(money);
    }
    setLocalStorage() {
        this.price_sum = 0;
        var list = JSON.parse(localStorage.getItem('list_product_card'));
        if (list != null && this.loading == false) {
            for (var i = 0; i < list.length; i++) {
                var data = list[i] as portal_san_pham_chi_tiet_card_model;
                this.list_product_card.push(data);
            }
        }
        this.loading = true;
        if (this.loading == true) {
            localStorage.removeItem('list_product_card');
            localStorage.setItem(
                'list_product_card',
                JSON.stringify(this.list_product_card)
            );
        }
        if (this.list_product_card && this.list_product_card.length) {
            this.price_sum = this.list_product_card
                .map((c) => c.gia_ban * c.so_luong)
                .reduce((sum, current) => sum + current);
        }
    }
    add_san_pham_to_card(
        item: portal_san_pham_chi_tiet_card_model,
        type: number
    ) {
        let so_luong = item.so_luong;

        if (type == 1) {
            item.so_luong = 1;
        }
        if (type == 2) {
            item.so_luong = -1;
        }
        this._shoppingCardsService.create(item);
        item.so_luong = so_luong;
    }

    /**
     * Delete the given notification
     */
    delete(product: any): void {
        // Delete the notification
        this.list_product_card = this.list_product_card.filter(
            (q) =>
                q.id != product.id &&
                q.id_size != product.id_size &&
                q.id_color != product.id_color
        );
        this.setLocalStorage();
        product.so_luong = 0;
        this._shoppingCardsService.create(product);
    }
    ngOnInit(): void {
        this.pageLoading = true;
        // Subscribe to notification changes
        this._portalShoppingCartService.product$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((product: portal_san_pham_chi_tiet_card_model) => {
                if (product != null) {
                    // Load the list_product_card
                    var item = this.list_product_card.find(
                        (q) =>
                            q.id == product.id &&
                            q.id_size == product.id_size &&
                            q.id_color == product.id_color
                    );
                    if (item != null && item != undefined) {
                        this.list_product_card = this.list_product_card.filter(
                            (q) => q.id != product.id
                        );
                        product.so_luong += item.so_luong;
                    }
                    this.list_product_card.push(product);
                }
                this.setLocalStorage();
                // Mark for check
                this._changeDetectorRef.markForCheck();
            });
        AOS.init({ duration: 1000 });
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.gio_hang');
        var metaTag = [
            {
                property: 'og:url',
                content: 'https://i.ibb.co/FnnkQCL/Logo.jpg',
            },
            {
                property: 'og:title',
                content: title,
            },
            {
                property: 'og:image',
                content: '../assets/images/common/images/img_2807.png',
            },
            {
                property: 'og:description',
                content: '',
            },
        ];
        this.seoService.updateTitle(title);
        this.seoService.updateMetaTags(metaTag);
        this.pageLoading = false;
        //update UnreadCount real time
        this._changeDetectorRef.markForCheck();
    }
}
