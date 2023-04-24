import { Component } from '@angular/core';
import { CartService } from '../../../core/services/api/cart.service';
import { OrderService } from '../../../core/services/api/order.service';
import { MenuItem } from '../../../core/types/menu.types';
import { newGuid } from '../../../core/utils/utils';

@Component({
	selector: 'app-cart',
	templateUrl: './cart-show.component.html',
	styleUrls: ['./cart-show.component.scss'],
})
export class CartShowComponent {
	constructor(private cartService: CartService, private orderService: OrderService) {
		this.cartService.cartSum.subscribe({
			next: (sum) => {
				this.cartSum = sum;
			},
		});
	}

	public cart: MenuItem[] = this.cartService.currentCart;
	public cartSum: number = 0;

	public changeParameters(menuItem: MenuItem, quantity: number): void {
		if (!menuItem.quantity) {
			menuItem.quantity = 0;
		}
		if (quantity < 0 && menuItem.quantity === 0) {
			return;
		}
		menuItem.quantity += quantity;

		this.cartService.updateCart(this.cart);
	}

	public pay(): void {
		this.orderService.createOrder({ id: newGuid(), status: 'Paid', sum: this.cartSum }).subscribe({
			next: () => {
				this.cartService.clearCart();
				this.cart = [];
			},
		});
	}

	public cancelOrder(): void {
		this.cartService.clearCart();
		this.cart = this.cartService.currentCart;
	}
}
