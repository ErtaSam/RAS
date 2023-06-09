import { RouteInfo } from '../types/route.types';

export const Routes: RouteInfo[] = [
	{
		path: '/profile',
		title: 'menu.profile',
		icon: 'fa-regular fa-user',
		type: 'link',
	},
	{
		path: '/menu',
		title: 'menu.menu',
		icon: 'fa-solid fa-bars',
		type: 'link',
	},
	{
		path: '/cart',
		title: 'menu.cart',
		icon: 'fa-solid fa-cart-shopping',
		type: 'link',
	},
	{
		path: '/orders',
		title: 'menu.orders',
		icon: 'fa-solid fa-circle-check',
		type: 'link',
	},
];
