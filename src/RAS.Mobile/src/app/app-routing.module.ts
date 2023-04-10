import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnlyAuthorizedGuard } from './core/guards/only-authorized.guard';
import { OnlyUnauthorizedGuard } from './core/guards/only-unauthorized.guard';
import { MainLayoutComponent } from './layouts/main/main-layout.component';
import { UnauthorizedLayoutComponent } from './layouts/unauthorized/unauthorized-layout.component';

const routes: Routes = [
	{
		path: '',
		component: MainLayoutComponent,
		canActivate: [OnlyAuthorizedGuard],
		children: [
			{
				path: 'profile',
				loadChildren: () => import('./features/profile/profile.module').then((x) => x.ProfileModule),
				canLoad: [OnlyAuthorizedGuard],
			},
			{
				path: 'menu',
				loadChildren: () => import('./features/menu/menu.module').then((x) => x.MenuModule),
				canLoad: [OnlyAuthorizedGuard],
			},
		],
	},
	{
		path: '',
		canActivate: [OnlyUnauthorizedGuard],
		component: UnauthorizedLayoutComponent,
		loadChildren: () => import('./features/auth/auth.module').then((x) => x.AuthModule),
	},
	{
		path: '**',
		redirectTo: '/profile',
	},
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
