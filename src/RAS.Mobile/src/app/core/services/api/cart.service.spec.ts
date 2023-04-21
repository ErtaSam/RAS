import { TestBed } from '@angular/core/testing';

import { CartService } from './cart.service';

describe('CartService', () => {
	let service: CartService;

	beforeEach(() => {
		TestBed.configureTestingModule({});
		service = TestBed.inject(CartService);
	});

	it('should be created', () => {
		expect(service).toBeTruthy();
	});

	describe('addToCart', () => {
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
	});
});
