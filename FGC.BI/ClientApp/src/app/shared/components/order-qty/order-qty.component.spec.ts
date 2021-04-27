import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderQtyComponent } from './order-qty.component';

describe('OrderQtyComponent', () => {
  let component: OrderQtyComponent;
  let fixture: ComponentFixture<OrderQtyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderQtyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderQtyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
