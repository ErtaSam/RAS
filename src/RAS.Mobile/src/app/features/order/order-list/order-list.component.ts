import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../core/services/api/order.service';
import { Order } from '../../../core/types/order.types';
import { newGuid } from '../../../core/utils/utils';

@Component({
	selector: 'app-order-list',
	templateUrl: './order-list.component.html',
	styleUrls: ['./order-list.component.scss'],
})
export class OrderListComponent implements OnInit {
	constructor(private orderService: OrderService) {
		// nothing
	}

	public orders: Order[] = [];

	public ngOnInit(): void {
		this.orderService.getLast().subscribe({
			next: (orders) => {
				this.orders = orders;
			},
		});
	}

	public pay(sum: number): void {
		this.orderService.createOrder({ id: newGuid(), status: 'Paid', sum: sum }).subscribe({
			next: () => {
				this.ngOnInit();
			},
		});
	}
}
