import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { IconButtonModule } from '../../core/components/icon-button/icon-button.module';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderShowComponent } from './order-show/order-show.component';
import { OrderRoutingModule } from './order.routing';

@NgModule({
	declarations: [OrderShowComponent, OrderListComponent],
	imports: [CommonModule, OrderRoutingModule, TranslateModule, IconButtonModule],
})
export class OrderModule {}
