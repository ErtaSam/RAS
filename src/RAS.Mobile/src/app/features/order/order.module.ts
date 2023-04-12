import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { OrderShowComponent } from './order-show/order-show.component';
import { OrderRoutingModule } from './order.routing';

@NgModule({
	declarations: [OrderShowComponent],
	imports: [CommonModule, OrderRoutingModule, TranslateModule],
})
export class OrderModule {}
