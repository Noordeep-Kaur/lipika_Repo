import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportrouteComponent } from './reportroute.component';

describe('ReportrouteComponent', () => {
  let component: ReportrouteComponent;
  let fixture: ComponentFixture<ReportrouteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportrouteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportrouteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
