import { TestBed } from '@angular/core/testing';

import { MemeberService } from './memeber.service';

describe('MemeberService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MemeberService = TestBed.get(MemeberService);
    expect(service).toBeTruthy();
  });
});
