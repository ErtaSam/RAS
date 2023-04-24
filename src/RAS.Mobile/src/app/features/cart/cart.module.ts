import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { TranslateModule } from '@ngx-translate/core';
import { LabelModule } from '@progress/kendo-angular-label';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { IconButtonModule } from '../../core/components/icon-button/icon-button.module';
import { CartShowComponent } from './cart-show/cart-show.component';
import { CartRoutingModule } from './cart.routing';

@NgModule({
	declarations: [CartShowComponent],
	imports: [CommonModule, CartRoutingModule, TranslateModule, LayoutModule, LabelModule, IonicModule, IconButtonModule],
})
export class CartModule {}
