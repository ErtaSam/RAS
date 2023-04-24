import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { DateOnlyPickerComponent } from './date-only-picker.component';

@NgModule({
	declarations: [DateOnlyPickerComponent],
	imports: [CommonModule, DatePickerModule, TranslateModule],
	exports: [DateOnlyPickerComponent],
})
export class DateOnlyPickerModule {}
