import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DateOnlyPickerModule } from '../../core/components/date-only-picker/date-only-picker.module';

import { ProfileComponent } from './profile.component';
import { ProfileRoutingModule } from './profile.routing';

@NgModule({
	declarations: [ProfileComponent],
	imports: [
		CommonModule,
		ProfileRoutingModule,
		CommonModule,
		TranslateModule,
		FormsModule,
		ReactiveFormsModule,
		InputsModule,
		GridModule,
		LabelModule,
		DropDownsModule,
		DatePickerModule,
		ButtonModule,
		DateOnlyPickerModule,
	],
})
export class ProfileModule {}
