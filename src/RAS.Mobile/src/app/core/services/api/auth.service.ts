import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, forkJoin, Observable, tap } from 'rxjs';
import { LoginRequest, LoginResponse, RegisterRequest } from '../../types/auth.types';
import { AccountService } from '../account.service';
import { AlertService } from '../alert.service';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	constructor(
		private http: HttpClient,
		private accountService: AccountService,
		private router: Router,
		private alertService: AlertService,
	) {
		this.isAuthenticated = this.getToken() !== null;
	}

	public isAuthenticated: boolean = false;
	public isAuthenticatedSubject = new BehaviorSubject<boolean>(false);

	private readonly tokenStorage: string = 'ras-mobile-authentication';
	private readonly loginRoute: string = '/login';

	public login(request: LoginRequest): Observable<LoginResponse> {
		return this.http.post<LoginResponse>(`/api/auth/login`, request).pipe(
			tap({
				next: (response) => {
					localStorage.setItem(this.tokenStorage, response.accessToken);
					this.isAuthenticated = true;

					forkJoin([this.accountService.getCurrentUser()]).subscribe({
						next: () => {
							this.router.navigate(['/menu']);
							this.isAuthenticatedSubject.next(true);
						},
					});
				},
				error: () => {
					this.alertService.error('ERROR.ERROR_INCORRECT_CREDENTIALS');
				},
			}),
		);
	}

	public register(request: RegisterRequest): Observable<void> {
		return this.http.post<void>('/api/auth/register', request).pipe(
			tap({
				next: () => {
					this.router.navigate([this.loginRoute]);
				},
			}),
		);
	}

	public logout(): void {
		localStorage.removeItem(this.tokenStorage);
		this.accountService.discardUserDataOnSignOut();
		this.isAuthenticated = false;
		this.router.navigate([this.loginRoute]);
		this.isAuthenticatedSubject.next(false);
	}

	public getToken(): string | null {
		return localStorage.getItem(this.tokenStorage);
	}
}
