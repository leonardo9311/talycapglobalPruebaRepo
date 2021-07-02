import { TestBed } from '@angular/core/testing';

import { AuthenticatheService } from './authenticathe.service';

describe('AuthenticatheService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AuthenticatheService = TestBed.get(AuthenticatheService);
    expect(service).toBeTruthy();
  });
});
