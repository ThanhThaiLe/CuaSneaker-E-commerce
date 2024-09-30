import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NhanHieuComponent } from './nhan-hieu.component';

describe('NhanHieuComponent', () => {
  let component: NhanHieuComponent;
  let fixture: ComponentFixture<NhanHieuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NhanHieuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NhanHieuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
