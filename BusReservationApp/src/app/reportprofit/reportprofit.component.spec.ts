import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportprofitComponent } from './reportprofit.component';

describe('ReportprofitComponent', () => {
  let component: ReportprofitComponent;
  let fixture: ComponentFixture<ReportprofitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportprofitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportprofitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
