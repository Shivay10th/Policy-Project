import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPolicyDisplayComponent } from './user-policy-display.component';

describe('UserPolicyDisplayComponent', () => {
  let component: UserPolicyDisplayComponent;
  let fixture: ComponentFixture<UserPolicyDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserPolicyDisplayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPolicyDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
