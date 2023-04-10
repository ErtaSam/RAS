import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AvailableCultures } from '../../constants/culture.constants';
import { Culture } from '../../types/culture.types';

@Component({
	selector: 'culture-change',
	templateUrl: './culture-change.component.html',
	styleUrls: ['./culture-change.component.scss'],
})
export class CultureChangeComponent implements OnInit {
	constructor(private translateService: TranslateService) {
		// Nothing
	}

	public cultures: Culture[] = [];
	public selected?: Culture = AvailableCultures.find((x) => x.isoCode === this.translateService.getDefaultLang());

	public ngOnInit(): void {
		this.cultures = AvailableCultures;
	}

	public onCultureChange(selected: Culture): void {
		this.translateService.use(selected.isoCode);

		this.selected = selected;
	}
}
