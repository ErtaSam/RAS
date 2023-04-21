import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HttpClientModule } from '@angular/common/http';
import { RouterTestingModule } from '@angular/router/testing';
import { TranslateModule } from '@ngx-translate/core';
import { OrderShowComponent } from './order-show.component';

describe('OrderShowComponent', () => {
	let component: OrderShowComponent;
	let fixture: ComponentFixture<OrderShowComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [OrderShowComponent],
			imports: [HttpClientModule, RouterTestingModule, TranslateModule.forRoot()],
		}).compileComponents();

		fixture = TestBed.createComponent(OrderShowComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
