import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SliderGridDataComponent } from './slider-grid-data.component';

describe('SliderGridDataComponent', () => {
  let component: SliderGridDataComponent;
  let fixture: ComponentFixture<SliderGridDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SliderGridDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SliderGridDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
