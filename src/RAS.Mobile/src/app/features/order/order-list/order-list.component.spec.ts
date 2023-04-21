import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HttpClientModule } from '@angular/common/http';
import { RouterTestingModule } from '@angular/router/testing';
import { TranslateModule } from '@ngx-translate/core';
import { OrderListComponent } from './order-list.component';

describe('OrderListComponent', () => {
	let component: OrderListComponent;
	let fixture: ComponentFixture<OrderListComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [OrderListComponent],
			imports: [HttpClientModule, RouterTestingModule, TranslateModule.forRoot()],
		}).compileComponents();

		fixture = TestBed.createComponent(OrderListComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
