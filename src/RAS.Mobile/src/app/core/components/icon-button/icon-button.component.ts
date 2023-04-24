import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
	selector: 'icon-button',
	templateUrl: './icon-button.component.html',
})
export class IconButtonComponent {
	@Input()
	public icon: string = '';

	@Input()
	public buttonClass: string = 'btn btn-primary';

	@Input()
	public title: string = '';

	@Input()
	public disabled: boolean = false;

	@Input()
	public expand: string = 'full';

	@Output()
	// eslint-disable-next-line @angular-eslint/no-output-on-prefix
	public onClick: EventEmitter<void> = new EventEmitter<void>();
}
