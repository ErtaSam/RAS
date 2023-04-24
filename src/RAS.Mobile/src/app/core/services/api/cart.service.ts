import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Menu, MenuItem } from '../../types/menu.types';

@Injectable({
	providedIn: 'root',
})
export class CartService {
	private cart: MenuItem[] = [];

	public get currentCart(): MenuItem[] {
		return this.cart;
	}

	public cartSumSubject = new BehaviorSubject<number>(0);

	public get cartSum(): Observable<number> {
		return this.cartSumSubject.asObservable();
	}

	public addToCart(menu: Menu[]): void {
		menu.forEach((m) => {
			m.menuItems.forEach((menuItem) => {
				const item = this.cart.find((x) => x.name === menuItem.name);
				if (item) {
					if (!item.quantity) item.quantity = 0;
					item.quantity += menuItem.quantity ?? 0;
				} else if (menuItem.quantity && menuItem.quantity > 0) {
					this.cart.push(menuItem);
				}
			});
		});

		this.updateSum();
	}

	public clearCart(): void {
		this.cart = [];
		this.cartSumSubject.next(0);
	}

	public updateCart(menuItem: MenuItem[]): void{
		this.cart = menuItem;
		this.updateSum();
	}
	private updateSum(): void{
		this.cartSumSubject.next(this.cart.reduce((sum, item) => sum + item.price * item.quantity!, 0));
	}


}
