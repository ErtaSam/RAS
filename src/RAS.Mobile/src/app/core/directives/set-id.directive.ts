import { AfterViewInit, Directive, ElementRef, Input } from '@angular/core';

@Directive({
	selector: '[setId]',
})
export class SetIdDirective implements AfterViewInit {
	constructor(private elementRef: ElementRef) {
		// Nothing
	}

	@Input()
	public setId!: string;

	public ngAfterViewInit(): void {
		// eslint-disable-next-line max-len
		// eslint-disable-next-line @typescript-eslint/no-unsafe-assignment, @typescript-eslint/no-unsafe-member-access, @typescript-eslint/no-unsafe-call
		const input = this.elementRef.nativeElement.querySelector('input');
		// eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
		input.id = this.setId;
	}
}
