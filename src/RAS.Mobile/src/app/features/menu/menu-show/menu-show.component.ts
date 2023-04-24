import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { debounceTime, switchMap } from 'rxjs';
import { CartService } from '../../../core/services/api/cart.service';
import { MenuService } from '../../../core/services/api/menu.service';
import { GetMenuRequest, Menu, MenuItem } from '../../../core/types/menu.types';

@Component({
	selector: 'app-menu-show',
	templateUrl: './menu-show.component.html',
	styleUrls: ['./menu-show.component.scss'],
})
export class MenuShowComponent implements OnInit {
	constructor(private menuService: MenuService, private route: ActivatedRoute, private router: Router, private cartService: CartService) {
		// Nothing
	}

	public request?: GetMenuRequest;
	public menu: Menu[] = [];

	public get buttonDisabled(): boolean {
		return !this.menu.some((m) => m.menuItems.some((menuItem) => menuItem.quantity && menuItem.quantity > 0));
	}

	public ngOnInit(): void {
		this.initParameterMap();
	}

	public changeQuantity(menuItem: MenuItem, quantity: number): void {
		if (!menuItem.quantity) {
			menuItem.quantity = 0;
		}
		if (quantity < 0 && menuItem.quantity === 0) {
			return;
		}
		menuItem.quantity += quantity;
	}

	private initParameterMap(): void {
		this.route.queryParamMap
			.pipe(
				debounceTime(250),

				switchMap((params) => {
					this.request = {
						name: params.get('name'),
						type: params.get('type'),
					};
					return this.menuService.getMenu(this.request);
				}),
			)
			.subscribe({
				next: (response) => {
					this.menu = response;
				},
			});
	}

	public onFilterChange(params: Params): void {
		this.router.navigate(['.'], {
			relativeTo: this.route,
			queryParamsHandling: 'merge',
			queryParams: params,
		});
	}

	public addToCart(): void {
		this.menuService.getMenu(this.request as GetMenuRequest).subscribe({
			next: (response) => {
				this.menu = response;
			},
		});

		this.cartService.addToCart(this.menu);
	}
}
