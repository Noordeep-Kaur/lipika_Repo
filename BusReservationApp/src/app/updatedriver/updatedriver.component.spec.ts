import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatedriverComponent } from './updatedriver.component';

describe('UpdatedriverComponent', () => {
  let component: UpdatedriverComponent;
  let fixture: ComponentFixture<UpdatedriverComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatedriverComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatedriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
