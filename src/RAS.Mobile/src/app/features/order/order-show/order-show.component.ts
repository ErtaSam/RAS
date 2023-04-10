import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderService } from '../../../core/services/api/order.service';
import { Order } from '../../../core/types/order.types';

@Component({
	selector: 'app-order-show',
	templateUrl: './order-show.component.html',
	styleUrls: ['./order-show.component.scss'],
})
export class OrderShowComponent implements OnInit {
	constructor(private orderService: OrderService, private activatedRoute: ActivatedRoute) {
		// nothing
	}

	public order?: Order;

	public ngOnInit(): void {
		this.activatedRoute.params.subscribe({
			next: (response) => {
				const orderId = response['id'] as string;

				this.orderService.getOrder(orderId).subscribe({
					next: (order) => {
						this.order = order;
					},
				});
			},
		});
	}
}
