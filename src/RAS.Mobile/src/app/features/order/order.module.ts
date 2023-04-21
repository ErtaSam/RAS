import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { OrderShowComponent } from './order-show/order-show.component';
import { OrderRoutingModule } from './order.routing';
import { OrderListComponent } from './order-list/order-list.component';

@NgModule({
	declarations: [OrderShowComponent, OrderListComponent],
	imports: [CommonModule, OrderRoutingModule, TranslateModule],
})
export class OrderModule {}
