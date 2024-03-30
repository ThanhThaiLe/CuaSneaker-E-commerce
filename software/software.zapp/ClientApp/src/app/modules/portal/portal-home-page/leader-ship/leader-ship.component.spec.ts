import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderShipComponent } from './leader-ship.component';

describe('LeaderShipComponent', () => {
  let component: LeaderShipComponent;
  let fixture: ComponentFixture<LeaderShipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaderShipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaderShipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
