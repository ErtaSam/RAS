import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/services/api/auth.service';
import { RegisterRequest } from '../../../core/types/auth.types';
import { CustomValidators } from '../../../core/validators/custom.validators';

@Component({
	selector: 'register',
	templateUrl: './register.component.html',
})
export class RegisterComponent {
	constructor(private authService: AuthService) {
		// Nothing
	}

	public form: FormGroup = new FormGroup(
		{
			firstName: new FormControl<string>('', [Validators.required]),
			lastName: new FormControl<string>('', [Validators.required]),
			email: new FormControl<string>('', [Validators.required, Validators.email]),
			phone: new FormControl<string>('', [Validators.required]),
			birthDate: new FormControl<string | undefined>(undefined, [Validators.required]),
			password: new FormControl<string>('', [Validators.required]),
			confirmPassword: new FormControl<string>('', [Validators.required]),
		},
		{
			validators: [CustomValidators.matchPasswords],
		},
	);

	public signUp(request: RegisterRequest): void {
		this.authService.register(request).subscribe();
	}

	public getControl(name: string): FormControl {
		return this.form.get(name) as FormControl;
	}
}
