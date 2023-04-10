import { Component, OnInit } from '@angular/core';
import { MenuService } from '../../../core/services/api/menu.service';
import { Menu, MenuItem } from '../../../core/types/menu.types';

@Component({
	selector: 'app-menu-show',
	templateUrl: './menu-show.component.html',
	styleUrls: ['./menu-show.component.scss'],
})
export class MenuShowComponent implements OnInit {
	constructor(private menuService: MenuService) {
		// Nothing
	}

	public menu: Menu[] = [];

	public ngOnInit(): void {
		this.menuService.getMenu().subscribe({
			next: (menu) => {
				this.menu = menu;
			},
		});
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
}
