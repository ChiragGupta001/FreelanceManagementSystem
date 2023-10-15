import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvidedServicesComponent } from './provided-services.component';

describe('ProvidedServicesComponent', () => {
  let component: ProvidedServicesComponent;
  let fixture: ComponentFixture<ProvidedServicesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProvidedServicesComponent]
    });
    fixture = TestBed.createComponent(ProvidedServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
