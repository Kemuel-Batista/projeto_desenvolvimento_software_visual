import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoriaServicosComponent } from './categoria-servicos.component';

describe('CategoriaServicosComponent', () => {
  let component: CategoriaServicosComponent;
  let fixture: ComponentFixture<CategoriaServicosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoriaServicosComponent]
    });
    fixture = TestBed.createComponent(CategoriaServicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
