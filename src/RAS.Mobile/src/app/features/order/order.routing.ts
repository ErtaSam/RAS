import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnlyAuthorizedGuard } from '../../core/guards/only-authorized.guard';
import { OrderShowComponent } from './order-show/order-show.component';

const routes: Routes = [
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
