import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SliderSecondComponent } from './slider-second.component';

describe('SliderSecondComponent', () => {
  let component: SliderSecondComponent;
  let fixture: ComponentFixture<SliderSecondComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SliderSecondComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SliderSecondComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
