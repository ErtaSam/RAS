import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DateOnlyPickerModule } from '../../core/components/date-only-picker/date-only-picker.module';
import { CommonDirectivesModule } from '../../core/directives/common-directives.module';
import { AuthRouting } from './auth.routing';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
	declarations: [LoginComponent, RegisterComponent],
	imports: [
		CommonModule,
		AuthRouting,
		TranslateModule,
		ReactiveFormsModule,
		InputsModule,
		LabelModule,
		DateOnlyPickerModule,
		CommonDirectivesModule,
	],
})
export class AuthModule {}
