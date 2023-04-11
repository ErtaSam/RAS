import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { IconButtonModule } from '../../core/components/icon-button/icon-button.module';
import { MenuShowComponent } from './menu-show/menu-show.component';

import { MenuRoutingModule } from './menu.routing';

@NgModule({
	declarations: [MenuShowComponent],
	imports: [CommonModule, MenuRoutingModule, LayoutModule, IconButtonModule, TranslateModule, InputsModule, LabelModule, FormsModule],
})
export class MenuModule {}
