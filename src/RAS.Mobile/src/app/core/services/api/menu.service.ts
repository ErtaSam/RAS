import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetMenuRequest, Menu } from '../../types/menu.types';

@Injectable({
	providedIn: 'root',
})
export class MenuService {
	constructor(private http: HttpClient) {
		//
	}

	public getMenu(request: GetMenuRequest): Observable<Menu[]> {
		return this.http.get<Menu[]>(`/api/menu`, {
			params: {
				name: request.name?.toString() ?? '',
			},
		});
	}
}
