import { Component } from '@angular/core';
import { CartService } from '../../../core/services/api/cart.service';
import { MenuItem } from '../../../core/types/menu.types';

@Component({
	selector: 'app-cart',
	templateUrl: './cart-show.component.html',
	styleUrls: ['./cart-show.component.scss'],
})
export class CartShowComponent {
	constructor(private cartService: CartService) {
		this.cartService.cartSum.subscribe({
			next: (sum) => {
				this.cartSum = sum;
			},
		});
	}

	public cart: MenuItem[] = this.cartService.currentCart;
	public cartSum: number = 0;
}
