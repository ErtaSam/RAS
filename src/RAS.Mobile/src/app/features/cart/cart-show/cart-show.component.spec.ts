import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { TranslateModule } from '@ngx-translate/core';
import { CartService } from 'src/app/core/services/api/cart.service';
import { MenuItem } from 'src/app/core/types/menu.types';
import { CartShowComponent } from './cart-show.component';

describe('CartShowComponent', () => {
	let component: CartShowComponent;
	let fixture: ComponentFixture<CartShowComponent>;
	let service: CartService;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [CartShowComponent],
			imports: [HttpClientModule, RouterTestingModule, TranslateModule.forRoot()],
		}).compileComponents();

		service = TestBed.inject(CartService);
		fixture = TestBed.createComponent(CartShowComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});

	it('should add new items to the cart', () => {
		const menu = [
			{
				id: '1',
				type: 'Pagrindinis',
				name: 'Menu 1',
				menuItems: [
					{ id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 2 },
					{ id: '2', name: 'Item 2', category: 'Gėrimai', price: 3, quantity: 1 },
				],
			},
			{
				id: '2',
				type: 'Pusryčiai',
				name: 'Menu 2',
				menuItems: [{ id: '3', name: 'Item 3', category: 'Gėrimai', price: 2, quantity: 1 }],
			},
		];
		service.addToCart(menu);
		const cart = service.currentCart;

		expect(cart.length).toEqual(3);
		expect(cart[0]).toEqual({ id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 2 });
		expect(cart[1]).toEqual({ id: '2', name: 'Item 2', category: 'Gėrimai', price: 3, quantity: 1 });
		expect(cart[2]).toEqual({ id: '3', name: 'Item 3', category: 'Gėrimai', price: 2, quantity: 1 });
	});

	it('should not add items to the cart if their quantity is 0', () => {
		const menu = [
			{
				id: '1',
				type: 'Pagrindinis',
				name: 'Menu 1',
				menuItems: [
					{ id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 0 },
					{ id: '2', name: 'Item 2', category: 'Gėrimai', price: 3, quantity: 0 },
				],
			},
		];
		service.addToCart(menu);
		const cart = service.currentCart;
		expect(cart.length).toEqual(0);
	});

	it('should decrease item quantity when the minus button is clicked', () => {
		const item: MenuItem = { id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 2 };
		component.cart = [item];
		fixture.detectChanges();

		component.changeParameters(item, -1);

		// assert quantity and total price updated correctly
		expect(component.cart[0].quantity).toBe(1);
	});

	it('should increase item quantity when the plus button is clicked', () => {
		const item: MenuItem = { id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 2 };
		component.cart = [item];
		fixture.detectChanges();

		component.changeParameters(item, 1);

		expect(component.cart[0].quantity).toBe(3);
	});

	it('should decrease item price when the minus button is clicked', () => {
		const item: MenuItem = { id: '1', name: 'Item 1', category: 'Gėrimai', price: 4, quantity: 2 };
		component.cart = [item];
		fixture.detectChanges();

		component.changeParameters(item, -1);
		fixture.detectChanges();

		expect(component.cart).withContext('2');
	});

	it('should increase item price when the plus button is clicked', () => {
		const item: MenuItem = { id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 1 };
		component.cart = [item];
		fixture.detectChanges();

		component.changeParameters(item, 1);
		fixture.detectChanges();

		expect(component.cart).withContext('4');
	});

	xit('should remove item when quantity decreases to 0', () => {
		const item: MenuItem = { id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 1 };
		component.cart = [item];
		fixture.detectChanges();

		component.changeParameters(item, -1);

		fixture.detectChanges();

		expect(component.cart.length).toBe(0);
	});

	it('should remove all items from the cart', () => {
		const item: MenuItem = { id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 1 };
		component.cart = [item];

		component.cancelOrder();

		expect(component.cart.length).toBe(0);
	});

	it('should reset the cartSum', () => {
		const item: MenuItem = { id: '1', name: 'Item 1', category: 'Gėrimai', price: 2, quantity: 1 };
		component.cart = [item];

		component.cancelOrder();

		expect(component.cartSum).toBe(0);
	});
});
