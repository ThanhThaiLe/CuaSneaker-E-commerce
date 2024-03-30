import { InjectionToken } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { portal_san_pham_chi_tiet_card_model } from 'app/modules/portal/portal.types';
export interface CardState {
    total: number;
    count: number;
    list_product_card?: portal_san_pham_chi_tiet_card_model[] | [];
}

export const CARD_STATE = new InjectionToken<RxState<CardState>>('CARD_STATE');
