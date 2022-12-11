import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyDetailDisplayComponent } from './policy-detail-display.component';

describe('PolicyDetailDisplayComponent', () => {
  let component: PolicyDetailDisplayComponent;
  let fixture: ComponentFixture<PolicyDetailDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PolicyDetailDisplayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolicyDetailDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
