import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportbustypeComponent } from './reportbustype.component';

describe('ReportbustypeComponent', () => {
  let component: ReportbustypeComponent;
  let fixture: ComponentFixture<ReportbustypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportbustypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportbustypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
