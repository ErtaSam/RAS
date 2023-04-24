import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../../types/order.types';

@Injectable({
	providedIn: 'root',
})
export class OrderService {
	constructor(private http: HttpClient) {
		// nothing
	}

	public getOrders(): Observable<Order[]> {
		return this.http.get<Order[]>(`/api/order`);
	}

	public getOrder(orderId: string): Observable<Order> {
		return this.http.get<Order>(`/api/order/${orderId}`);
	}

	public createOrder(order: Order): Observable<Order> {
		return this.http.post<Order>(`/api/order`, order);
	}
	public getLast(): Observable<Order[]> {
		return this.http.get<Order[]>(`/api/order/Last`);
	}
}
