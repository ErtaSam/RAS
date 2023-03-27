import { Component } from '@angular/core';

@Component({
	selector: 'navbar',
	templateUrl: './navbar.component.html',
	styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
	public isAuthorized: boolean = false;

	public signOut(): void {
		// this.authService.logout();
	}

	public toggleSidebar = (): void => {
		const layoutDiv = <HTMLElement>document.getElementById('MainLayout');

		layoutDiv.classList.toggle('g-sidenav-pinned');
		layoutDiv.classList.toggle('g-sidenav-hidden');
	};
}
