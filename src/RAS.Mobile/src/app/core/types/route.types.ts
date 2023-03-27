declare type MenuType = 'sub' | 'link';

export type RouteInfo = {
	isVisible?: boolean;
	path: string;
	title: string;
	type: MenuType;
	icon: string;
	collapse?: string;
	isCollapsed?: boolean;
	children?: RouteInfo[];
};
