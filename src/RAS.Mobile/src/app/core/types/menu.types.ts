export type MenuItem = {
	id: string;
	name: string;
	category: string;
	price: number;
	quantity?: number;
};

export type Menu = {
	id: string;
	type: string;
	name: string;
	menuItems: MenuItem[];
	visible?: boolean;
};

export type GetMenuRequest = {
	name: string | null;
	type: string | null;
};
