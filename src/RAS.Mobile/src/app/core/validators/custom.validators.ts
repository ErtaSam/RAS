import { AbstractControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

export class CustomValidators {
	public static get phone(): ValidatorFn {
		return Validators.pattern('^\\+[0-9]{10,12}$');
	}

	public static get matchPasswords(): ValidatorFn {
		return (control: AbstractControl): ValidationErrors | null => {
			const password = control.get('password')?.value as string;
			const confirmPassword = control.get('confirmPassword')?.value as string;
			if (password !== confirmPassword) {
				control.get('confirmPassword')?.setErrors({ MatchPassword: true });
			} else {
				control.get('confirmPassword')?.setErrors(null);
			}
			return null;
		};
	}
}
