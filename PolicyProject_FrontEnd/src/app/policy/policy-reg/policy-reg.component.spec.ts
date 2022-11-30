import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyRegComponent } from './policy-reg.component';

describe('PolicyRegComponent', () => {
  let component: PolicyRegComponent;
  let fixture: ComponentFixture<PolicyRegComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PolicyRegComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolicyRegComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
