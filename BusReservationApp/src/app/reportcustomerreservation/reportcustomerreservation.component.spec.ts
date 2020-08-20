import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportcustomerreservationComponent } from './reportcustomerreservation.component';

describe('ReportcustomerreservationComponent', () => {
  let component: ReportcustomerreservationComponent;
  let fixture: ComponentFixture<ReportcustomerreservationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportcustomerreservationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportcustomerreservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
