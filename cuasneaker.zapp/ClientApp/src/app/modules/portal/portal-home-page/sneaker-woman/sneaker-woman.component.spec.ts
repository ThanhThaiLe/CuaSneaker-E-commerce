import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SneakerWomanComponent } from './sneaker-woman.component';

describe('SneakerWomanComponent', () => {
  let component: SneakerWomanComponent;
  let fixture: ComponentFixture<SneakerWomanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SneakerWomanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SneakerWomanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
