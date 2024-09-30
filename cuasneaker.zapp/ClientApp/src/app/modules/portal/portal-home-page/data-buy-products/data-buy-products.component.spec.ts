import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataBuyProductsComponent } from './data-buy-products.component';

describe('DataBuyProductsComponent', () => {
  let component: DataBuyProductsComponent;
  let fixture: ComponentFixture<DataBuyProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataBuyProductsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DataBuyProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
