import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Menu } from '../../types/menu.types';

@Injectable({
	providedIn: 'root',
})
export class MenuService {
	constructor(private http: HttpClient) {
		//
	}

	public getMenu(): Observable<Menu[]> {
		return this.http.get<Menu[]>(`/api/menu`);
	}
}
