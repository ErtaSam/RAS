import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { OrderShowComponent } from './order-show/order-show.component';
import { OrderRoutingModule } from './order.routing';

@NgModule({
	declarations: [OrderShowComponent],
	imports: [CommonModule, OrderRoutingModule],
})
export class OrderModule {}
