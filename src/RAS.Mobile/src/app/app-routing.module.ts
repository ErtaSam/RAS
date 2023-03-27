import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './layouts/main/main-layout.component';
import { UnauthorizedLayoutComponent } from './layouts/unauthorized/unauthorized-layout.component';

const routes: Routes = [
	{
		path: '',
		component: MainLayoutComponent,
		children: [],
	},
	{
		path: '',
		component: UnauthorizedLayoutComponent,
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
