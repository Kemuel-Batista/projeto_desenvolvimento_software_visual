import { TestBed } from '@angular/core/testing';

import { CategoriaServicosService } from './categoria-servicos.service';

describe('CategoriaServicosService', () => {
  let service: CategoriaServicosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoriaServicosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
