import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnlyAuthorizedGuard } from '../../core/guards/only-authorized.guard';
import { MenuShowComponent } from './menu-show/menu-show.component';

const routes: Routes = [
	{
		path: '',
		component: MenuShowComponent,
		canActivate: [OnlyAuthorizedGuard],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class MenuRoutingModule {}
