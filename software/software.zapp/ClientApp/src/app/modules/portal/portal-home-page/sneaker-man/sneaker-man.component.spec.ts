import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SneakerManComponent } from './sneaker-man.component';

describe('SneakerManComponent', () => {
  let component: SneakerManComponent;
  let fixture: ComponentFixture<SneakerManComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SneakerManComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SneakerManComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
