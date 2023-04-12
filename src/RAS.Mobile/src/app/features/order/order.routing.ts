import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnlyAuthorizedGuard } from '../../core/guards/only-authorized.guard';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderShowComponent } from './order-show/order-show.component';

const routes: Routes = [
	{
		path: '',
		component: OrderListComponent,
		canActivate: [OnlyAuthorizedGuard],
	},
	{
		path: ':id',
		component: OrderShowComponent,
		canActivate: [OnlyAuthorizedGuard],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class OrderRoutingModule {}
