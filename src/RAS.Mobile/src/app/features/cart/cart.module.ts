import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { LabelModule } from '@progress/kendo-angular-label';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { CartShowComponent } from './cart-show/cart-show.component';
import { CartRoutingModule } from './cart.routing';

@NgModule({
	declarations: [CartShowComponent],
	imports: [CommonModule, CartRoutingModule, TranslateModule, LayoutModule, LabelModule],
})
export class CartModule {}
