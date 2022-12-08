import { TestBed } from '@angular/core/testing';

import { JwtInterceptorSrvService } from './jwt-interceptor-srv.service';

describe('JwtInterceptorSrvService', () => {
  let service: JwtInterceptorSrvService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtInterceptorSrvService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
