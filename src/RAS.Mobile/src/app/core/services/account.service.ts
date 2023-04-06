import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { User } from '../types/user.types';

@Injectable({
	providedIn: 'root',
})
export class AccountService {
	constructor(private http: HttpClient) {
		// Nothing
	}

	private currentUserSubject = new BehaviorSubject<User | null>(null);
	private currentPermissionsSubject = new BehaviorSubject<string[]>([]);

	public get currentUser(): Observable<User | null> {
		return this.currentUserSubject.asObservable();
	}

	public get currentPermissions(): Observable<string[]> {
		return this.currentPermissionsSubject.asObservable();
	}

	public getCurrentUser(): Observable<User> {
		return this.http.get<User>('api/profile').pipe(
			tap({
				next: (account) => {
					this.currentUserSubject.next(account);
				},
			}),
		);
	}

	private discardCurrentUser(): void {
		this.currentUserSubject.next(null);
	}

	public discardUserDataOnSignOut(): void {
		this.discardCurrentUser();
	}
}
