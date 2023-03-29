import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/services/api/auth.service';
import { LoginRequest } from '../../../core/types/auth.types';

@Component({
	selector: 'login',
	templateUrl: './login.component.html',
})
export class LoginComponent {
	constructor(private authService: AuthService) {
		// Nothing
	}

	public form: FormGroup = new FormGroup({
		email: new FormControl<string>('', [Validators.required, Validators.email]),
		password: new FormControl<string>('', [Validators.required]),
	});

	public signIn(request: LoginRequest): void {
		this.authService.login(request).subscribe();
	}
}
