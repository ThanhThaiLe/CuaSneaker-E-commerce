import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GirdProductsComponent } from './gird-products.component';

describe('GirdProductsComponent', () => {
  let component: GirdProductsComponent;
  let fixture: ComponentFixture<GirdProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GirdProductsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GirdProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
