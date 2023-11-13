import { Component, OnInit } from '@angular/core';
import { Routes } from '../../constants/route.constants';
import { RouteInfo } from '../../types/route.types';

@Component({
	selector: 'sidebar',
	templateUrl: './sidebar.component.html',
	styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
	public routes: RouteInfo[] = [];

	public ngOnInit(): void {
		this.routes = Routes.map((route) => {
			this.updateIsVisible(route);
			return route;
		});
		this.routes = Routes.filter((menuItem) => menuItem.isVisible);
	}

	public updateIsVisible(route: RouteInfo): void {
		route.isVisible = true;
		if (route.children) {
			route.children.forEach((child) => {
				this.updateIsVisible(child);
				route.children = route.children?.filter((rc) => rc.isVisible);
			});
		}
	}

	public toggleSidebar(open?: boolean): void {
		const layoutDiv = <HTMLElement>document.getElementById('MainLayout');

		if (open === true) {
			layoutDiv.classList.remove('g-sidenav-hidden');
			layoutDiv.classList.add('g-sidenav-pinned');
		} else if (open === false) {
			layoutDiv.classList.remove('g-sidenav-pinned');
			layoutDiv.classList.add('g-sidenav-hidden');
		} else {
			layoutDiv.classList.toggle('g-sidenav-pinned');
			layoutDiv.classList.toggle('g-sidenav-hidden');
		}
	}
}
